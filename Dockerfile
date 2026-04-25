FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Tüm proje dosyalarını ana dizinden kopyala
COPY . .

# WebUI projesine odaklan ve bağımlılıkları çöz
RUN dotnet restore "Villa.WebUI/Villa.WebUI.csproj"

# Yayınla (Bu aşama tildaların bakacağı dosyaları paketler)
RUN dotnet publish "Villa.WebUI/Villa.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Çalışma ortamı
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Paketlenen her şeyi (wwwroot dahil) buraya al
COPY --from=build /app/publish .

# Tildaların 'ana dizin' olarak burayı görmesini sağlıyoruz
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

ENTRYPOINT ["dotnet", "Villa.WebUI.dll"]