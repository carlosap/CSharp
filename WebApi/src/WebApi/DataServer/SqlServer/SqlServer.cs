using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApi.TraceInfo;

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
                try
                {
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
                }
                catch (Exception ex)
                {

                    Trace.TraceError(ex.ToString());
                }
                Tracer.Msg($"GetConnectionString:SqlServer.cs:line 44", results);
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
                        await con.OpenAsync();
                        using (var command = new SqlCommand(storeProc, con))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = storeProc;
                            command.CommandTimeout = await GetTimeOut();
                            if (parameters.Count > 0)
                                foreach (var param in parameters)
                                    command.Parameters.AddWithValue(param.Key, param.Value);
                            await command.ExecuteReaderAsync();
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
                        await con.OpenAsync();
                        using (var command = new SqlCommand(storeProc, con))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = storeProc;
                            command.CommandTimeout = await GetTimeOut();
                            if (parameters?.Count > 0)
                                foreach (var param in parameters)
                                    command.Parameters.AddWithValue(param.Key, param.Value);
                            using (var reader = await command.ExecuteReaderAsync())
                                while (await reader.ReadAsync())
                                {
                                    //TODO: Figure out why when deployed database is empty
                                    await Tracer.Msg($"usp_GetJsonValueAsync:SqlServer.cs:line 104", reader["json"].ToString());
                                    results = reader["json"]?.ToString().Trim().Replace("\r", "").Replace("\n", "").Replace("\t", "");
                                }

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
                await Tracer.Msg($"usp_GetJsonValueAsync:SqlServer.cs:line 120", results);
                return results;
            });
        }
    }
}

