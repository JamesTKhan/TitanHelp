# TitanHelp
SPC School project

# Database
By default the application is setup to use a in-memory "stub" database to make collaboration easier for the team. You can optionally enable the application to use a real (sqlite) database by changing the appsettings.Development.json property UseStubDb to false.

## Sqlite setup

In Visual Studio click Tools>Nuget Package Manager>Package Manager Console
 
### Run the following to add needed dependencies for the Sqlite database
Install-Package Microsoft.EntityFrameworkCore.Sqlite   
Install-Package Microsoft.EntityFrameworkCore.Tools
 
### Run the following to get the database table created
Update-Database
 
