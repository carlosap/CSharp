Name:UserClientRepository:Add
Exception: System.InvalidOperationException: No database provider has been configured for this DbContext. A provider can be configured by overriding the DbContext.OnConfiguring method or by using AddDbContext on the application service provider. If AddDbContext is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor and passes it to the base constructor for DbContext.
   at Microsoft.EntityFrameworkCore.Internal.DatabaseProviderSelector.SelectServices()
   at Microsoft.EntityFrameworkCore.Internal.LazyRef`1.get_Value()
   at Microsoft.EntityFrameworkCore.Infrastructure.EntityFrameworkServiceCollectionExtensions.<>c.<AddEntityFramework>b__0_11(IServiceProvider p)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ScopedCallSite.Invoke(ServiceProvider provider)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService[T](IServiceProvider provider)
   at Microsoft.EntityFrameworkCore.Infrastructure.AccessorExtensions.GetService[TService](IInfrastructure`1 accessor)
   at Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade.EnsureCreated()
   at WebDbServer.Repository.UserClientRepository.<>c__DisplayClass0_0.<<Add>b__0>d.MoveNext() in C:\Users\cperez\Documents\Visual Studio 2015\Projects\WebDbServer\src\WebDbServer\Repository\UserClient\UserClientRepository.cs:line 20