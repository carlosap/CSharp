//using System.Threading.Tasks;
//using System;
//using WebApi.Model.UserClient;
//using WebApi.DataServer.Contexts;
//using WebApi.Interfaces.UserClients;
//using System.Linq;

//namespace WebApi.Repository
//{
//    public class UserClientRepository: IUserClient
//    {
//        public async Task Add(string firstName, string lastName, string email, string tel, bool emailEnable=true, bool textEnable=true)
//        {
//            await Task.Run(async () =>
//            {
//                try
//                {
//                    using (var context = new UserClientsContext())
//                    {
//                        context.Database.EnsureCreated();
//                        var user = new UserClient
//                        {
//                            FirstName = firstName,
//                            LastName = lastName,
//                            Email = email,
//                            Phone = tel,
//                            EmailEnable = emailEnable,
//                            TextEnable = textEnable
//                        };
//                        context.Add(user);
//                        await context.SaveChangesAsync();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    await TraceInfo.Tracer.Exception("UserClientRepository:Add", ex);
//                }
//            });
//        }

//        public async Task Delete(string email)
//        {
//            await Task.Run(async () =>
//            {
//                try
//                {
//                    using (var context = new UserClientsContext())
//                    {
//                        var user = context.Clients.FirstOrDefault(b => b.Email == email);
//                        if (user != null)
//                        {
//                            context.Remove((object) user);
//                            await context.SaveChangesAsync();
//                        }                     
//                    }
//                }
//                catch (Exception ex)
//                {
//                    await TraceInfo.Tracer.Exception("UserClientRepository:Add", ex);
//                }
//            });
//        }

//        public async Task<UserClient> GetUserByEmail(string email)
//        {
//            var user = new UserClient();
//            return await Task.Run(async () =>
//            {             
//                try
//                {
//                    using (var context = new UserClientsContext())
//                        user = context.Clients.FirstOrDefault(b => b.Email == email);
//                }
//                catch (Exception ex)
//                {
//                    await TraceInfo.Tracer.Exception("UserClientRepository:Add", ex);
//                }
//                return user;
//            });          
//        }

//        public async Task Update(string firstName, string lastName, string email, string tel, bool emailEnable = true, bool textEnable = true)
//        {
//            await Task.Run(async () =>
//            {
//                try
//                {
//                    using (var context = new UserClientsContext())
//                    {
//                        var user = context.Clients.FirstOrDefault(b => b.Email == email);
//                        if (user != null)
//                        {
//                            user.FirstName = firstName;
//                            user.LastName = lastName;
//                            user.Email = email;
//                            user.Phone = tel;
//                            user.EmailEnable = emailEnable;
//                            user.TextEnable = textEnable;
//                            await context.SaveChangesAsync();
//                        }


//                    }
//                }
//                catch (Exception ex)
//                {
//                    await TraceInfo.Tracer.Exception("UserClientRepository:Add", ex);
//                }
//            });
//        }
//    }
//}

