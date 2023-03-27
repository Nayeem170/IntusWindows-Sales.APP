# About this application
This is a Blazor WebAssembly application that displays data from a database through a user interface. For the backend functionality, we have integrated it with a .NET API. The application interface has been designed using MatBlazor. We have used SQL Server as the database. You can manipulate orders within the application as we have already provided the seed data with the migration. Once you run the application, you can experiment with it.

# Required tools:
- [net6.0 runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Visual Studio 22](https://visualstudio.microsoft.com/vs/community/)
- [SQL Server 22](https://www.microsoft.com/en-us/sql-server/sql-server-2022)

# Running Instructions:
1. Clone the git repository using this link: https://github.com/Nayeem170/IntusWindows-Sales.APP

![Git clone](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/01.PNG)

2. Switch to the develop branch

![develop branch](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/02.PNG)

3. Go to the SalesSolution folder, then Double-click on the SalesSolution.sln file to open the project in Visual Studio

![SalesSolution.sln](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/03.PNG)

4. Update the database connection string (SalesDBConnection) in the SalesSolution\Sales.Api\appsettings.json file

![SalesDBConnection](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/04.png)

5. Set Sales.API as the startup project

![startup project](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/05.PNG)

6. Open the Package Manager Console

![Package Manager Console](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/06.png)

7. Select Sales.DAL from the default project, and run the migration command, "Update-Database"

![Package Manager Console](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/07.PNG)

8. Ends of succeful migration you will see Done ends of it

![Done](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/08.PNG)

9. Right-click on the SalesSolution, then select Configure Startup Project

![Configure Startup Project](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/09.png)

10. Select Sales.API and Sales.APP as startup projects

![Sales.API and Sales.APP](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/10.png)

11. Click on Start to run the application

![Start](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/11.png)

12. The application will open on your browser at https://localhost:7247/

![Start](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/12.png)

# Project architecture

I chose onion architecture for this project. The reason for selecting onion architecture in this project is because it facilitates the separation of concerns by arranging code into layers. This, in turn, leads to a codebase that is more manageable and testable while decreasing interdependencies among different components of the system.

![project architecture](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/18.png)

# Project overview

1. The project displayed with no data

![no data](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/17.png)

2. The project presented with seed data

![seed data](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/13.png)

3. Form validation when adding a new order

![Form validation](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/15.png)

4. The response to creating a sub-element with invalid data was displayed in a toast

![Toast](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/16.png)

5. Swagger documentation page of our API project

![Swagger](https://github.com/Nayeem170/IntusWindows-Sales.APP/blob/develop/Resources/Images/14.png)
