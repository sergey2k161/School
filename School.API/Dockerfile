﻿FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["School.API/School.API.csproj", "School.API/"]
COPY ["School.DataBase/School.DataBase.csproj", "School.DataBase/"]
COPY ["School.Bussiness/School.Bussiness.csproj", "School.Bussiness/"]
RUN dotnet restore "School.API/School.API.csproj"
COPY . .
WORKDIR "/src/School.API"
RUN dotnet build "School.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "School.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "School.API.dll"]
