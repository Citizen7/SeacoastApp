# Seacoast Labratory Data Systems Application
By Megan Nourse

## Overview
This is a .NET Core 6 MVC application. It uses Entity Framework Core to create and interface with a SQL backend. The original request suggested using mockup data, but as I don't have any mock JSON servers that allow treating multiple files as different databases, using real SQL structure just made more sense.

Bootstrap v5 is used for structure. Style is "Lumen" from Bootswatch.com.

## To Run the Program
1. Restore database-bk.bak file to the SQL Server instance of your choice. This database contains the tables dbo.Addresses, dbo.Employees, and dbo.SalesUnits, populated with the data from the original JSON files.
2. Modify appsettings.json/appsettings.Development.json to change `"DefaultConnection": "Server=localhost\\ZEN7SQL; Database=SeacoastApp; Trusted_Connection=True;"` to match the server where you restored the database.
3. Build and run the application!