# Address Standardization Web Service

## Описание

Этот веб-сервис выполняет стандартизацию адресов с использованием API Dadata. Сервис принимает "сырой" адрес через HTTP-запрос, отправляет его на сервис Dadata для обработки и возвращает стандартизированный адрес в формате JSON.

## Стек технологий

- **ASP.NET Core 7**
- **C#**
- **HttpClientFactory**
- **AutoMapper**
- **Dadata API**
- **Dependency Injection (DI)**
- **Logging**
- **CORS**
- **Configuration Management**

## Основные компоненты

- **DadataService**: сервис для взаимодействия с API Dadata.
- **AddressController**: контроллер для обработки запросов на стандартизацию адресов.
- **AutoMapper**: используется для маппинга данных между моделями `AddressResponseDto` и `AddressDto`.
- **Configuration**: параметры для доступа к API Dadata (API ключ и секретный ключ) берутся из файла конфигурации `appsettings.json`.

## Настройка проекта

### 1. Клонирование репозитория

``
git clone https://github.com/Exponentik/AddressStandartization
``  
``cd API``  
### 2. Конфигурация Dadata
Замените данные в файле appsettings.json в каталоге API проекта на необходимые:  
```
{
  "Dadata": {
    "BaseUrl": "https://cleaner.dadata.ru/api/v1/clean/address",
    "ApiKey": "ваш_api_key",
    "SecretKey": "ваш_secret_key"
  }
}
```
### 3. Запуск приложения
Для запуска приложения выполните команду:  
``dotnet run``  
Приложение будет доступно по адресу https://localhost:5178.

### 4. Использование API
Отправьте GET-запрос с "сырым" адресом, например:

``GET https://localhost:5178/api/address/standardize?rawAddress=Москва, Красная площадь, д.1``  
Ответ будет в формате JSON:  
```
{
  "result": "Россия, г Москва, Красная площадь, д 1",
  "postalCode": "109012",
  "country": "Россия",
  "region": "Москва",
  "city": "Москва",
  "street": "Красная площадь",
  "house": "1"
}
```  
