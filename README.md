# Weather API, External API Integration with .NET 8

A lightweight **ASP.NET Core Web API** that fetches real-time weather data from the [Open-Meteo API](https://open-meteo.com/) using `HttpClient`.  
Built to demonstrate **external API integration**, **dependency injection**, **DTO mapping**, and **error handling** in a clean architecture style.

## Features

- Fetches current weather data (temperature & wind speed) from an external public API  
- Uses **HttpClient Factory** (`AddHttpClient`) with dependency injection  
- Includes **city coordinate management** for pre-defined cities  
- error handling with clear API responses 
- Built with **.NET 8** and **Swagger UI** for testing  

## API Endpoint

**GET** `/api/weather/{city}`  
Fetches current weather for a supported city.

## Example:
GET https://localhost:7120/api/weather/Tbilisi

Response (200 OK):

{
  "city": "Tbilisi",
  "temperature": 11.4,
  "windSpeed": 3.6
}

Response (404 Not Found):


{ "message": "Invalid city name: London. Available city weathers are for: Tbilisi, Berlin, Paris" }


# Clone the repo
git clone https://github.com/Rati5832/WeatherApi.git
cd WeatherApi

# Restore dependencies
dotnet restore

# Run the API
dotnet run --project Weather.Api

# Then open your browser at
https://localhost:7120/swagger
