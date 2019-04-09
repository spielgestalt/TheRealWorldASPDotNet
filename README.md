# TheRealWorldASPDotNet
A Real World REST API Example in ASP.NET
## Development Machine Specs
* MacOS Mojave 10.14.*
* [Visual Studio Community for Mac Version 8.0.*] (https://visualstudio.microsoft.com/de/vs/mac/)
* [Docker for Mac](https://docs.docker.com/docker-for-mac/install/)
* [Azure Data Studio for Mac](https://docs.microsoft.com/de-de/sql/azure-data-studio/download?view=sql-server-2017)
* [Kitura](https://www.kitura.io/app.html)

## Setup Project
### Setup Database
We slightly changed the walkthrough on [How to set up a full-stack .NET web development environment on Mac OS](https://codeburst.io/how-to-set-up-a-modern-full-stack-net-web-development-environment-on-mac-os-542dcd43a564) setting up the MSSQL server in docker. We pulled the latest mssql server with

`docker pull microsoft/mssql-server-linux`

and start the server with

```
docker run -e 'ACCEPT_EULA=Y' \
-e 'SA_PASSWORD=Passw0rd!' \
-p 1433:1433 \
--name mssql_the_real_world \
-d microsoft/mssql-server-linux
```

The Project was created as a .NET Core App -> WebApp MVC with no dependencies added. (sqlServer is already in the default package)

## Todos
* Database setup with basic **Page** and **ContentElemet** 
* Implement basic REST Controller for **Page** *in progress*
* Authentication
* Authorization
* Simple REST Endpoint

### Resources and Documentation used for this project
* [**Medium** - How to set up a full-stack .NET web development environment on Mac OS](https://codeburst.io/how-to-set-up-a-modern-full-stack-net-web-development-environment-on-mac-os-542dcd43a564)
* [**Medium** - An awesome guide on how to build RESTful APIs with ASP.NET Core](https://medium.freecodecamp.org/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28)

### Problems while creating this Project
