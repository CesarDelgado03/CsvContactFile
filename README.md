# Contact Csv Application

This App objective is to upload a csv file indicating the required columns for then be process 
saving data into a table

## Technologies

* [.Net core 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
* [Identity Authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)

## System Requirements

* [Microsoft SQL server LocalDb](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)
* .Net Core 5 SDK
* Visual Studio 2019

## Installation

Follow the next steps to get a working copy of the app

1. Clone the repository.
2. Execute migrations using: 
```shell 
Update-Database -Context AppDbContext
``` 
or 
```shell
dotnet ef database update --context AppDbContext
```
4. run the application
5. Register a user or login using c1@yahoo.com password = Az123456*
6. create a csv file to upload and indicate the column positions of the required filds

## Notes

* If you have any dependency problem, try running the following command in the root folder:

  ```shell
  dotnet restore
  ```