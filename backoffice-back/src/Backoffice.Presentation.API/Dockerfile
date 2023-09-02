FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Backoffice.Presentation.API/Backoffice.Presentation.API.csproj", "src/Backoffice.Presentation.API/"]
RUN dotnet restore "src/Backoffice.Presentation.API/Backoffice.Presentation.API.csproj"
COPY . .
WORKDIR "/src/src/Backoffice.Presentation.API"
RUN dotnet build "Backoffice.Presentation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backoffice.Presentation.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backoffice.Presentation.API.dll"]
