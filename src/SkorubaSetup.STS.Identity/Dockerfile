FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SkorubaSetup.STS.Identity/SkorubaSetup.STS.Identity.csproj", "src/SkorubaSetup.STS.Identity/"]
COPY ["src/SkorubaSetup.Admin.EntityFramework.Shared/SkorubaSetup.Admin.EntityFramework.Shared.csproj", "src/SkorubaSetup.Admin.EntityFramework.Shared/"]
COPY ["src/SkorubaSetup.Shared/SkorubaSetup.Shared.csproj", "src/SkorubaSetup.Shared/"]
RUN dotnet restore "src/SkorubaSetup.STS.Identity/SkorubaSetup.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/SkorubaSetup.STS.Identity"
RUN dotnet build "SkorubaSetup.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkorubaSetup.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "SkorubaSetup.STS.Identity.dll"]