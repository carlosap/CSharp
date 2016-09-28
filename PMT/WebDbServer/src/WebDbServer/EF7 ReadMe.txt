Tools:
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools –Pre

Start:
Add-Migration init
Update-Database

Updates:
If you make future changes to your model, you can use the 
Add-Migration command to scaffold a new migration to make the 
corresponding schema changes to the database. 
Once you have checked the scaffolded code (and made any required changes), you can use the 
Update-Database command to apply the changes to the database.

When you have multiple contexts (basically classes deribe from contextdb).
you need to specify the command -Context

Add-Migration userclient -Context UserClientContext
Update-Database -Context UserClientContext

