FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["SSLibrary.API/SSLibrary.API.csproj", "SSLibrary.API/"]
RUN dotnet restore "SSLibrary.API/SSLibrary.API.csproj"
COPY . .
WORKDIR "/src/SSLibrary.API"
RUN dotnet build "SSLibrary.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SSLibrary.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSLibrary.API.dll"]
