//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Threading.Tasks;
//using WebApi.Model.UserClient;
//using WebApi.TraceInfo;
//namespace WebApi.DataServer.Contexts
//{
//    public class UserClientsContext : DbContext
//    {

//        public DbSet<UserClient> Clients { get; set; }
//        protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            var connectionString = await GetConnectionString();
//            base.OnConfiguring(optionsBuilder);
//            optionsBuilder.UseSqlServer(connectionString);
//        }
//        private static async Task<string> GetConnectionString()
//        {
//            return await Task.Run(() =>
//            {
//                var results = string.Empty;
//                try
//                {
//                    string strEnv = Startup.AppSettings.HostingEnvironment.Value;
//                    switch (strEnv)
//                    {
//                        case "Development":
//                            results = Startup.AppSettings.DatabaseSettings.SqlServerConnection.DevConnectionString;
//                            break;
//                        case "Staging":
//                            results = Startup.AppSettings.DatabaseSettings.SqlServerConnection.StagingConnectionString;
//                            break;
//                        default:
//                            results = Startup.AppSettings.DatabaseSettings.SqlServerConnection.ConnectionString;
//                            break;
//                    }
//                }
//                catch (Exception ex)
//                {

//                    Tracer.Error("UserClientsContext:GetConnectionString", ex.ToString());
//                }
//                return results;
//            });
//        }
//    }
//}
