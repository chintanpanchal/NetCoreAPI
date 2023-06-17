using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Talia;
using Talia.Connection;

namespace Talia.Helper
{
    public static class SqlHelper
    {
        public static async Task<IEnumerable<T>> GetRecords<T>(string spName, object parameters = default)
        {
            IEnumerable<T> records = new List<T>();
            using (SqlConnection objConnection = new(TaliaDbConnect.DBString))
            {
                objConnection.Open();
                var p = new DynamicParameters();
                p.AddDynamicParams(parameters);
                p.Add(DBUtilities.OUTPUT_PARAM, dbType: DbType.Int32, direction: ParameterDirection.Output);
                records = (await objConnection.QueryAsync<T>(spName, p, commandType: CommandType.StoredProcedure)).ToList();
                objConnection.Close();
            }
            return records;
        }
        public static async Task<T> GetRecord<T>(string spName, object parameters)
        {
            T record = default(T);
            using (SqlConnection objConnection = new(TaliaDbConnect.DBString))
            {
                objConnection.Open();
                var p = new DynamicParameters();
                p.AddDynamicParams(parameters);
                p.Add(DBUtilities.OUTPUT_PARAM, dbType: DbType.Int32, direction: ParameterDirection.Output);
                record = (await objConnection.QueryAsync<T>(spName, p, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                objConnection.Close();
            }
            return record;
        }
        public static async Task<int> Execute(string spName, CancellationToken cancellationToken, object parameters)
        {
            int affectedRow = 0;
            using (SqlConnection objConnection = new(TaliaDbConnect.DBString))
            {
                objConnection.Open();
                var p = new DynamicParameters();
                p.AddDynamicParams(parameters);
                p.Add(DBUtilities.OUTPUT_PARAM, dbType: DbType.Int32, direction: ParameterDirection.Output);
                affectedRow = await objConnection.ExecuteAsync(new CommandDefinition(
                     commandText: spName,
                     parameters: p,
                     commandType: CommandType.StoredProcedure,
                     cancellationToken: cancellationToken
                     ));
                objConnection.Close();
            }
            return affectedRow;
        }
        public static async Task<bool> ExecuteScalar<T>(string spName, object parameters)
        {
            bool isExists;
            using (SqlConnection objConnection = new(TaliaDbConnect.DBString))
            {
                objConnection.Open();
                var p = new DynamicParameters();
                p.AddDynamicParams(parameters);
                p.Add(DBUtilities.OUTPUT_PARAM, dbType: DbType.Int32, direction: ParameterDirection.Output);
                isExists = await objConnection.ExecuteScalarAsync<bool>(new CommandDefinition(
                     commandText: spName,
                     parameters: p,
                     commandType: CommandType.StoredProcedure
                     ));
                objConnection.Close();
            }
            return isExists;
        }
    }
}