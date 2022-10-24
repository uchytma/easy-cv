
#build FE stage
FROM node:lts-alpine AS build-spa-vue
WORKDIR /app
COPY ./App/easy-cv/package.json ./
COPY ./App/easy-cv/package-lock.json ./

RUN npm install
RUN npm install -g serve

COPY ./App/easy-cv ./
RUN npm run build


#build API stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY ./Api ./
RUN dotnet restore
RUN dotnet publish -c Release -o out


#production container
FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV ASPNETCORE_URLS=http://*:5000
ENV ASPNETCORE_ENVIRONMENT="production"
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-spa-vue /app/dist ./wwwroot
EXPOSE 5000
ENTRYPOINT ["dotnet", "EasyCv.Api.dll"]

