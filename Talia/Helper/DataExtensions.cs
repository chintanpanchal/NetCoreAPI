using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace Talia.Helper
{
    public static class DataExtensions
    {
        public static string RetriveJsonString(this IDataReader reader)
        {
            var jsonStr = string.Empty;
            using (var data = new DataTable())
            {
                data.Load(reader);
                jsonStr = JsonConvert.SerializeObject(data);
            }
            return jsonStr;
        }
    }
}
