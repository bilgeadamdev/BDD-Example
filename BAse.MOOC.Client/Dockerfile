FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BAse.MOOC.Client/BAse.MOOC.Client.csproj", "BAse.MOOC.Client/"]
RUN dotnet restore "BAse.MOOC.Client/BAse.MOOC.Client.csproj"
COPY . .
WORKDIR "/src/BAse.MOOC.Client"
RUN dotnet build "BAse.MOOC.Client.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BAse.MOOC.Client.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BAse.MOOC.Client.dll"]