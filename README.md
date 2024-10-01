# TitanHelp
SPC School project

TitanHelp and is a web-based support ticket system. It utilizes the Kestrel web server and .NET 8.0. The project uses Razor Pages for the presentation layer which offers binding with the domain layer. For the data layer EntityFramework is used along with Sqlite. The project offers a stubbed in-memory interface for testing the application without a database. When using Sqlite the project creates an sqlite ‘.db’ file at execution time in the local machines app data if one is not found.


# Database
By default the application is setup to use Sqlite. 

If any trouble is encountered with Sqlite, an in-memory "stub" database is available. You can optionally enable the application to use the stub database by changing the appsettings.Development.json property UseStubDb to true.
 
