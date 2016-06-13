using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
namespace WebApi.DataServer
{
    public class SqlServer : IDatabase
    {
        public SqlCommand SqlCommand { get; set; }
        public DatabaseServerType ServerType => DatabaseServerType.SqlServer;
        public SqlServer(){ Initialise();}
        public Task Initialise() => Task.Run(() => {
            SqlCommand = new SqlCommand();
        });
        public async Task<string> GetConnectionString()
        {
            return await Task.Run(() => {
                string results = string.Empty;
                string strEnv = Startup.AppSettings.HostingEnvironment.Value;
                switch (strEnv)
                {
                    case "Development":
                        results = Startup.AppSettings.DatabaseSettings.SqlServerConnection.DevConnectionString;
                        break;
                    case "Staging":
                        results = Startup.AppSettings.DatabaseSettings.SqlServerConnection.StagingConnectionString;
                        break;
                    default:
                        results = Startup.AppSettings.DatabaseSettings.SqlServerConnection.ConnectionString;
                        break;
                }
                return results;
            });
        }
        public async Task<int> GetTimeOut() => await Task.Run(() => {
            return (int)Startup.AppSettings.DatabaseSettings.SqlServerConnection.TimeOut;
        });
        public Task<string> usp_Exec(string storeProc, Dictionary<string, object> parameters)
        {
            return Task.Run(async () =>  {
                var results = string.Empty;
                try
                {
                    using (var con = new SqlConnection(await GetConnectionString()))
                    {
                        con.Open();
                        using (var command = new SqlCommand(storeProc, con))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = storeProc;
                            command.CommandTimeout = await GetTimeOut();
                            if (parameters.Count > 0)
                                foreach (var param in parameters)
                                    command.Parameters.AddWithValue(param.Key, param.Value);
                            command.ExecuteReader();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                }
                finally
                {
                    SqlCommand.Dispose();
                }
                return results;
            });
        }
        public Task<string> usp_GetJsonValueAsync(string storeProc, Dictionary<string, object> parameters)
        {
            return  Task.Run(async () =>
            {
                var results = string.Empty;
                try
                {
                    using (var con = new SqlConnection(await GetConnectionString()))
                    {
                        con.Open();
                        using (var command = new SqlCommand(storeProc, con))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = storeProc;
                            command.CommandTimeout = await GetTimeOut();
                            if (parameters?.Count > 0)
                                foreach (var param in parameters)
                                    command.Parameters.AddWithValue(param.Key, param.Value);
                            using (var reader = command.ExecuteReader())
                                while (reader.Read())
                                    results =
                                        reader["json"]?.ToString()
                                            .Trim()
                                            .Replace("\r", "")
                                            .Replace("\n", "")
                                            .Replace("\t", "");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                }
                finally
                {
                    SqlCommand.Dispose();
                }
                return results;
            });
        }
    }
}

