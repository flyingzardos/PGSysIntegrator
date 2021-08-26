#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/PGSysIntegrator.API/PGSysIntegrator.API.csproj", "Services/PGSysIntegrator.API/"]
COPY ["Services/PGSysIntegrator.Infrastructure/PGSysIntegrator.Infrastructure.csproj", "Services/PGSysIntegrator.Infrastructure/"]
COPY ["Services/PGSysIntegrator.Application/PGSysIntegrator.Application.csproj", "Services/PGSysIntegrator.Application/"]
COPY ["Services/PGSysIntegrator.Domain/PGSysIntegrator.Domain.csproj", "Services/PGSysIntegrator.Domain/"]
RUN dotnet restore "Services/PGSysIntegrator.API/PGSysIntegrator.API.csproj"
COPY . .
WORKDIR "/src/Services/PGSysIntegrator.API"
RUN dotnet build "PGSysIntegrator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PGSysIntegrator.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PGSysIntegrator.API.dll"]