# PdfGeneratorApp

PdfGeneratorApp - это приложение для генерации PDF-документов на основе данных о людях.

## Установка

1. Клонируйте репозиторий.
2. Установите зависимости через NuGet:
   - `Microsoft.EntityFrameworkCore`
   - `Microsoft.EntityFrameworkCore.Design`
   - `Npgsql.EntityFrameworkCore.PostgreSQL`
   - `MigraDoc.DocumentObjectModel`
   - `MigraDoc.Rendering`

3. Настройте строку подключения в `ApplicationDbContext`.

## Использование

1. Введите текст в поле ввода.
2. Нажмите кнопку "Печать" для генерации PDF с данными.

## Структура проекта

- **ViewModels**: Логика представления.
- **Services**: Сервисы для загрузки данных и генерации PDF.
- **Models**: Модели данных.
- **Data**: Контекст базы данных.
