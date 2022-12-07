using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoveryAppLibrary.Database
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDb(IConfiguration config)
        {
            _config = config;
        }
        //return rows of data back

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            //the using statements calls the dispose method when connection statement is done - whether there was an error or not. It will 
            //close the connection properly
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //takes stored procedure and the parameters  (safety check - data layer - ensure it is not any type of sql injection)
                //commandType - we are saying it is a stored procedure call not a regular text sql call - such as Select statement etc 
                var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                //A list of type T - Strongly type list of the model

                return rows.ToList();
            }

        }
        public async Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }

        }
    }
}
