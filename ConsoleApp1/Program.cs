// Cargo las librerías para poder leer el JSON
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeserializacionJSON
{
    // Clase donde se guardara el elemento Information y las propiedades Temperature, Wind, Humidy, Pressure
    // esto se hacer por cada propiedad
    public class Information
    {
        // Este atributo indica que al momento de realizar la deserialziacion debe tomar el valor del atributo temperature del JSON
        // Esto se aplica a todos los demás atributos
        [JsonPropertyName("temperature")]
        // Indico que tipo de variable es y su "visibilidad", adicional los atributos get y set indican que se puede asignar un valor
        // o tomar ese valor
        public string Temperature { get; set; }
        [JsonPropertyName("wind")]
        public string Wind { get; set; }
        [JsonPropertyName("humidity")]
        public string Humidity { get; set; }
        [JsonPropertyName("pressure")]
        public string Pressure { get; set; }
    }

    public class Locality
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("url_weather_forecast_15_days")]
        public string UrlWeatherForecast15Days { get; set; }
        [JsonPropertyName("url_hourly_forecast")]
        public string UrlHourlyForecast { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("url_country")]
        public string UrlCountry { get; set; }
    }

    // Clase donde se guardara el elemento Day
    public class Day
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("temperature_max")]
        public int TemperatureMax { get; set; }
        [JsonPropertyName("temperature_min")]
        public int TemperatureMin { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("wind")]
        public int Wind { get; set; }
        [JsonPropertyName("wind_direction")]
        public string WindDirection { get; set; }
        [JsonPropertyName("icon_wind")]
        public string IconWind { get; set; }
        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }
        [JsonPropertyName("moonrise")]
        public string Moonrise { get; set; }
        [JsonPropertyName("moonset")]
        public string Moonset { get; set; }
        [JsonPropertyName("moon_phases_icon")]
        public string MoonPhasesIcon { get; set; }
    }

    // Clase donde se guardará el elemento HourData
    public class HourData
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("hour_data")]
        public string HourDataValue { get; set; }
        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
        [JsonPropertyName("wind")]
        public int Wind { get; set; }
        [JsonPropertyName("wind_direction")]
        public string WindDirection { get; set; }
        [JsonPropertyName("icon_wind")]
        public string IconWind { get; set; }
    }

    // Instancia todas las demás clases de tal manera que clases para acceder directamente a dichos elementos y propiedades
    public class Root
    {
        // En estos casos accedo directamente a las propiedades 
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }
        [JsonPropertyName("use")]
        public string Use { get; set; }
        // Se instancias las clases
        [JsonPropertyName("information")]
        public Information Information { get; set; }
        [JsonPropertyName("web")]
        public string Web { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("locality")]
        public Locality Locality { get; set; }
        [JsonPropertyName("day1")]
        public Day Day1 { get; set; }
        [JsonPropertyName("day2")]
        public Day Day2 { get; set; }
        [JsonPropertyName("hour_hour")]
        public Dictionary<string, HourData> HourHour { get; set; }
    }

    // Se declara la clase principal del proyecto
    class Program
    {
        // Método principal que da inicio la proyecto, desde aquí inicia el programa como tal.
        static void Main(string[] args)
        {
            // Se estable la ruta completa del archivo
            string file = "C:\\Users\\USER\\source\\repos\\ConsoleApp1\\ConsoleApp1\\weatherV1.json";

            // Lee el archivo json y almacena la data dentro de una variable
            string jsonString = File.ReadAllText(file);

            // Deserializa el JSON e instancio la clase Root que a su vez instancia las demas clases de tal manera
            // de que todos los elementos del JSON y propiedades
            Root data = JsonSerializer.Deserialize<Root>(jsonString);

            // Ahora puedes acceder a los datos según sea necesario, por ejemplo:
            Console.WriteLine($"Temperaturas de la Ciudad: {data.Locality.Name}({data.Locality.Country})");
            // Muestra información detallada de un día, incluyendo temperaturas máximas y mínimas, amanecer y anochecer.
            Console.WriteLine($"Fecha {data.Day1.Date} | Temperatura máxima: {data.Day1.TemperatureMax}{data.Information.Temperature} | Temperatura mínima: {data.Day1.TemperatureMin}{data.Information.Temperature} | Amaneció a las {data.Day1.Sunrise}AM | Anocheció a las {data.Day1.Sunset}PM");
            Console.WriteLine($"Fecha {data.Day2.Date} | Temperatura máxima: {data.Day2.TemperatureMax}{data.Information.Temperature} | Temperatura mínima: {data.Day2.TemperatureMin}{data.Information.Temperature} | Amaneció a las {data.Day2.Sunrise}AM | Anocheció a las {data.Day2.Sunset}PM");
        }

    }
}
