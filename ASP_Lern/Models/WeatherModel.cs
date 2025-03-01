using System.Drawing;
using ASP_Lern.Services;
using System.Text.Json.Serialization;
namespace ASP_Lern.Models;

public class WeatherModel
{
    public string City { get; set; }
    public double Temperature { get; set; }
    public string Description { get; set; }

}

public class WeatherResponсe // Вспомогательный класс для JSON десериализации
{
    [JsonPropertyName( "coord" )]
    public Coord Coord { get; set; } // Координаты

    [JsonPropertyName( "weather" )]
    public Weather[] Weather { get; set; } // Массив с описанием погоды

    [JsonPropertyName( "main" )]
    public Main Main { get; set; } // Основные данные (температура, влажность)

    [JsonPropertyName( "visibility" )]
    public int Visibility { get; set; } // Видимость

    [JsonPropertyName( "wind" )]
    public Wind Wind { get; set; } // Данные о ветре

    [JsonPropertyName( "clouds" )]
    public Clouds Clouds { get; set; } // Облачность

    [JsonPropertyName( "base" )]
    public string Base { get; set; } // База данных (например, "stations")

    [JsonPropertyName( "sys" )]
    public Sys Sys { get; set; } // Системная информация

    [JsonPropertyName( "name" )]
    public string Name { get; set; } // Название города

    [JsonPropertyName( "cod" )]
    public int Cod { get; set; } // Код ответа

    [JsonPropertyName( "timezone" )]
    public int Timezone { get; set; } // Часовой пояс

    [JsonPropertyName( "id" )]
    public int Id { get; set; } // ID города

    public override string ToString()
    {
        return $"City: {Name}, Temperature: {Main?.Temp}, Weather: {Weather?[ 0 ]?.Description}";
    }
}

public class Coord
{
    [JsonPropertyName( "lon" )]
    public double Lon { get; set; } // Долгота

    [JsonPropertyName( "lat" )]
    public double Lat { get; set; } // Широта
}

public class Main
{
    [JsonPropertyName( "temp" )]
    public double Temp { get; set; } // Температура

    [JsonPropertyName( "feels_like" )]
    public double FeelsLike { get; set; } // Ощущаемая температура

    [JsonPropertyName( "temp_min" )]
    public double TempMin { get; set; } // Минимальная температура

    [JsonPropertyName( "temp_max" )]
    public double TempMax { get; set; } // Максимальная температура

    [JsonPropertyName( "pressure" )]
    public int Pressure { get; set; } // Давление

    [JsonPropertyName( "humidity" )]
    public int Humidity { get; set; } // Влажность

    [JsonPropertyName( "sea_level" )]
    public int SeaLevel { get; set; } // Уровень давления на уровне моря

    [JsonPropertyName( "grnd_level" )]
    public int GrndLevel { get; set; } // Уровень давления на земле
}

public class Weather
{
    [JsonPropertyName( "id" )]
    public int Id { get; set; } // ID погодного условия

    [JsonPropertyName( "main" )]
    public string Main { get; set; } // Главное описание

    [JsonPropertyName( "description" )]
    public string Description { get; set; } // Подробное описание

    [JsonPropertyName( "icon" )]
    public string Icon { get; set; } // Иконка
}
public class Wind
{
    [JsonPropertyName( "speed" )]
    public double Speed { get; set; } // Скорость ветра

    [JsonPropertyName( "deg" )]
    public int Deg { get; set; } // Направление ветра

    [JsonPropertyName( "gust" )]
    public double Gust { get; set; } // Порывы ветра
}
public class Clouds
{
    [JsonPropertyName( "all" )]
    public int All { get; set; } // Облачность (%)
}
public class Sys
{
    [JsonPropertyName( "type" )]
    public int Type { get; set; } // Тип

    [JsonPropertyName( "id" )]
    public int Id { get; set; } // ID

    [JsonPropertyName( "country" )]
    public string Country { get; set; } // Страна

    [JsonPropertyName( "sunrise" )]
    public int Sunrise { get; set; } // Время восхода

    [JsonPropertyName( "sunset" )]
    public int Sunset { get; set; } // Время заката
}