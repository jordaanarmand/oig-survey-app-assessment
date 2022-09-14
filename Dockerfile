FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OIG.Survey.App/OIG.Survey.App.csproj", "OIG.Survey.App/"]
RUN dotnet restore "OIG.Survey.App/OIG.Survey.App.csproj"
COPY . .
WORKDIR "/src/OIG.Survey.App"
RUN dotnet build "OIG.Survey.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OIG.Survey.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OIG.Survey.App.dll"]
