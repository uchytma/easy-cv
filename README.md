# easy-cv
Create your professional looking and printable CV in minutes.

**DEMO: https://easycv.azurewebsites.net**

## How to run (dev)

Backend (API) part is .net 6 application. It could be run from Visual Studio IDE or with `dotnet run` command.

Frontend part is vue 3 app, which can be run by command `npm dev`. (hotreload enabled)

## How to run (prod)

All commands must be run from project root.

```
docker build -t easy-cv -f .\Deployment\Dockerfile .
```

```
docker run --name easy-cv-instance --publish 5000:5000 easy-cv
```

Application is running at root url: `/`

GraphQL API: `/graphql`

## DB creating & migrations

The application uses SQlite as its database.
Database migrations are managed by ORM Entity Framework Core.

All commands must be run from easy-cv/Api/EasyCv.Infrastructure.Db directory.

You must always specify the connection string as the --connection param.

Install the EF tools (only if not already installed):
```
dotnet tool install --global dotnet-ef
```

Create/update database:
```
dotnet ef database update --connection "<connectionString>"
```

Add migration:
```
dotnet ef migrations add <migrationName> --connection "<connectionString>"
```

More EF CLI commands can be found at [doc](https://learn.microsoft.com/en-us/ef/core/cli/dotnet).

## Configuration

### DB connection string
you must provide Db Connection string under `ConnectionStrings:EasyCv` key.

Example: `"ConnectionStrings:EasyCv": "Data Source=C:\\dev\\easycv\\easycv.db"`


## Screenshots

![image](https://user-images.githubusercontent.com/28567403/197527180-c10ab4c9-b365-4c52-9d65-f86f9cc517e5.png)

