FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Villa.WebUI/Villa.WebUI.csproj", "Villa.WebUI/"]
RUN dotnet restore "Villa.WebUI/Villa.WebUI.csproj"
COPY . .
WORKDIR "/src/Villa.WebUI"
RUN dotnet build "Villa.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Villa.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Villa.WebUI.dll"]