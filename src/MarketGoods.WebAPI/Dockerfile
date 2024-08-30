# Используем образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию для сборки
WORKDIR /app

# Копируем файлы проектных файлов .csproj в рабочую директорию
COPY *.csproj ./

# Выполняем восстановление зависимостей проекта
RUN dotnet restore

# Копируем все остальные файлы в рабочую директорию
COPY . ./

# Собираем и публикуем приложение в выходную директорию "out" с конфигурацией "Release"
RUN dotnet publish -c Release -o out

# Используем образ .NET ASP.NET для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Устанавливаем рабочую директорию для запуска приложения
WORKDIR /app

# Копируем собранное приложение из предыдущего этапа в рабочую директорию
COPY --from=build /app/out .

# Устанавливаем точку входа для контейнера, чтобы запустить приложение
ENTRYPOINT ["dotnet", "MarketGoods.WebAPI.dll"]