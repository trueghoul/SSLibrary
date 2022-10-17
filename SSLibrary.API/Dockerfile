FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build-env
WORKDIR /App
COPY . ./
RUN dotnet restore
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "SSLibrary.API.dll"]