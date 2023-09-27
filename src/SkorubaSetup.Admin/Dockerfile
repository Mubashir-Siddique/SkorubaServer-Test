FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SkorubaSetup.Admin/SkorubaSetup.Admin.csproj", "src/SkorubaSetup.Admin/"]
COPY ["src/SkorubaSetup.Admin.EntityFramework.Shared/SkorubaSetup.Admin.EntityFramework.Shared.csproj", "src/SkorubaSetup.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaSetup.Admin.EntityFramework.SqlServer/SkorubaSetup.Admin.EntityFramework.SqlServer.csproj", "src/SkorubaSetup.Admin.EntityFramework.SqlServer/"]
COPY ["src/SkorubaSetup.Shared/SkorubaSetup.Shared.csproj", "src/SkorubaSetup.Shared/"]
COPY ["src/SkorubaSetup.Admin.EntityFramework.PostgreSQL/SkorubaSetup.Admin.EntityFramework.PostgreSQL.csproj", "src/SkorubaSetup.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/SkorubaSetup.Admin.EntityFramework.MySql/SkorubaSetup.Admin.EntityFramework.MySql.csproj", "src/SkorubaSetup.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/SkorubaSetup.Admin/SkorubaSetup.Admin.csproj"
COPY . .
WORKDIR "/src/src/SkorubaSetup.Admin"
RUN dotnet build "SkorubaSetup.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaSetup.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaSetup.Admin.dll"]