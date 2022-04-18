#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
#COPY ["nuget.config", "."]
COPY ["PRUEBA.QPH.API/PRUEBA.QPH.API.csproj", "PRUEBA.QPH.API/"]
RUN dotnet restore "PRUEBA.QPH.API/PRUEBA.QPH.API.csproj"
COPY . .
WORKDIR "/src/PRUEBA.QPH.API"
RUN dotnet build "PRUEBA.QPH.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PRUEBA.QPH.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PRUEBA.QPH.API.dll"]