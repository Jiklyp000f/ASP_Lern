using System.Text.Json;
using ASP_Lern.Models;
using ASP_Lern.Services;

namespace ASP_Lern.Services;
public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public WeatherService(HttpClient httpClient, string apiKey )
    {
        _httpClient = httpClient;
        _apiKey = apiKey;
    }

    public async Task<WeatherModel> GetWeatherAsync(string city )
    {

        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
        var response = await _httpClient.GetAsync( url );

        if ( !response.IsSuccessStatusCode )
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception( $"API request failed with status code {response.StatusCode}. Response: {errorContent}" );
        }

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine( "Raw JSON Response:" );
        Console.WriteLine( content );

        try
        {
            var weatherResponse = JsonSerializer.Deserialize<WeatherResponсe>( content );

            // Проверка на null
            if ( weatherResponse == null )
            {
                Console.WriteLine( "weatherResponse is NULL." );
                throw new Exception( "Invalid or incomplete weather data received." );
            }

            // Проверка наличия обязательных свойств
            if ( weatherResponse.Main == null )
            {
                Console.WriteLine( "weatherResponse.Main is NULL." );
                throw new Exception( "Main data is missing." );
            }

            if ( weatherResponse.Weather == null || weatherResponse.Weather.Length == 0 )
            {
                Console.WriteLine( "weatherResponse.Weather is NULL or empty." );
                throw new Exception( "Weather data is missing or incomplete." );
            }

            return new WeatherModel
            {
                City = weatherResponse.Name,
                Temperature = weatherResponse.Main.Temp,
                Description = weatherResponse.Weather[ 0 ].Description
            };
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Error during deserialization: {ex.Message}" );
            throw;
        }
    }
}
