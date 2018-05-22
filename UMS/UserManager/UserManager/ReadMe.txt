Server was create to take advantage of the toolings:
1- create your models and relations
2- make sure your startup.cs supports connection string
3- make sure you startup.cs supports your service
            string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Spartan;Integrated Security=True";
            services.AddDbContext<UserContext>(option => option.UseSqlServer(ConnectionString));
4- Use you Migration commands


PM>
PM>
PM> Add-Migration 0001_InitTables -Context UserContext
To undo this action, use Remove-Migration.
PM> Update-Database -Context UserContext
Applying migration '20180522124845_0001_InitTables'.
Done.
PM>

5- Verify you are able to see the tables.