FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["And.TimeTracker.Api/And.TimeTracker.Api.csproj", "And.TimeTracker.Api/"]
RUN dotnet restore "And.TimeTracker.Api/And.TimeTracker.Api.csproj"
COPY . .
WORKDIR "/src/And.TimeTracker.Api"
RUN dotnet build "And.TimeTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "And.TimeTracker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "And.TimeTracker.Api.dll"]
