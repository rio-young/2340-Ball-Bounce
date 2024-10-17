using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    private static readonly string apiKey = "b676a083c0e04ad68fe191945241710";  // Replace with your WeatherAPI key
    private static readonly string apiUrl = "http://api.weatherapi.com/v1/current.json?key={0}&q={1},{2}";

    static async Task Main(string[] args)
    {
        int n = 5; // Number of random locations to fetch

        for (int i = 0; i < n; i++)
        {
            (double lat, double lon) = GenerateRandomCoordinates();
            await GetTemperatureByCoordinates(lat, lon);
        }
    }

    static (double, double) GenerateRandomCoordinates()
    {
        Random random = new Random();
        // Generate latitude between -90 and 90
        double lat = random.NextDouble() * 180 - 90;
        // Generate longitude between -180 and 180
        double lon = random.NextDouble() * 360 - 180;
        return (lat, lon);
    }

    static async Task GetTemperatureByCoordinates(double lat, double lon)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = string.Format(apiUrl, apiKey, lat, lon);
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                JObject weatherData = JObject.Parse(json);
                double temperature = weatherData["current"]["temp_c"].ToObject<double>();
                string condition = weatherData["current"]["condition"]["text"].ToString();
                Console.WriteLine($"The temperature at coordinates ({lat}, {lon}) is {temperature}°C with {condition}.");
            }
            else
            {
                Console.WriteLine($"Could not get weather data for coordinates ({lat}, {lon}).");
            }
        }
    }
}