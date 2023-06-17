using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Talia.Helper;
using Talia.Connection;
using Talia.Models;
using Talia.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Talia.DataAccess
{
    public class Authentication : IAuthManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbConnect;
        private readonly IRoleManager<UserRoles> _roleManager;
        private readonly IUserManager<UserDetails> _userManager;
        private string _current_username;
        public Authentication(IConfiguration configuration,
            IRoleManager<UserRoles> roleManager,
            IUserManager<UserDetails> userManager)
        {
            _dbConnect = TaliaDbConnect.DBString;
            _configuration = configuration;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public string GenerateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                            issuer: _configuration["JwtIssuer"],
                            audience: _configuration["JwtAudience"],
                            claims: GetClaims(),
                            expires: DateTime.Now.AddMinutes(59),
                            signingCredentials: signinCredentials
                        );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
        public async Task<bool> ValidateCredentials(string _username, string _password)
        {
            var exists = false;
            _current_username = _username;
            var _param = new { Username = _username, Password = _password };
            using (var conn = new SqlConnection(_dbConnect))
            {
                exists = await SqlHelper.ExecuteScalar<bool>(DBUtilities.VALIDATE_USER_CREDENTIALS, _param);
            }
            return exists;
        }
        public List<Claim> GetClaims()
        {
            var claims = new List<Claim>();
            var current_user_id = _userManager.GetUserIdAsync(_current_username).Result;
            IEnumerable<string> current_user_roles = _roleManager.GetUserRolesAsync(current_user_id).Result;
            current_user_roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, current_user_id));
            claims.Add(new Claim(ClaimTypes.Name, _current_username));
            return claims;
        }
    }
}
