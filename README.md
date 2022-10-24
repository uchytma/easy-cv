# easy-cv
Create your professional looking and printable CV in minutes.

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

GraphQL UI: `/graphql/ui`

## Screenshots

![image](https://user-images.githubusercontent.com/28567403/197527180-c10ab4c9-b365-4c52-9d65-f86f9cc517e5.png)

