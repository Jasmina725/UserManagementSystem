
# User Management System
This is a User Management API that allows us to create, edit, view and delete users. 
It also provides assigning permissions to users. 
In addition to these some other functions like pagination, filtering and ordering are implemented. 
All changes are saved in database.

## Technology Stack

- Backend: .NET Core 3.1, Entity Framework Core 3.1.1
- Database: Microsoft SQL Server   
- Documentation: Swagger 5.5

## Running the application
- First, check the connection string in appsettings.json. Default Local DB connection string is used "Server=(LocalDb)\\MSSQLLocalDB; Database=UserManagementDB.
If you are using SSMS or your local server name is different, please change connection string.
 - Next, open the Package Manager Console and run update-database command.
- After that, you can run the application and API is ready to use.
