# About this application
This is a Blazor WebAssembly application that displays data from a database through a user interface. For the backend functionality, we have integrated it with a .NET API. The application interface has been designed using MatBlazor. We have used SQL Server as the database. You can manipulate orders within the application as we have already provided the seed data with the migration. Once you run the application, you can experiment with it.

# Required tools:
- net6.0 runtime
- Visual Studio 22
- SQL Server 22

# Running Instructions:
1. Clone the git repository using this link: https://github.com/Nayeem170/IntusWindows-Sales.APP
2. Switch to the develop branch
3. Go to the SalesSolution folder
4. Double-click on the SalesSolution.sln file to open the project in Visual Studio
5. Update the database connection string (SalesDBConnection) in the SalesSolution\Sales.Api\appsettings.json file
6. Set Sales.API as the startup project
7. Open the Package Manager Console
8. Select Sales.DAL from the default project
9. Run the migration command, "Update-Database"
10. Select Sales.API and Sales.APP as startup projects
11. Build and run the application
12. The application will open on your browser at https://localhost:7247/
