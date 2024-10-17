using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


public class LogicScript : MonoBehaviour
{

  public GameObject sampleObject;
  static int max_balls = 1020;
  public int num_balls;
  public List<GameObject> balls;
  private static readonly string apiKey = "b676a083c0e04ad68fe191945241710";  // Replace with your WeatherAPI key
    // private static readonly string apiUrl = "http://api.weatherapi.com/v1/current.json?key={0}&q={1},{2}";
    private static readonly string apiUrl = "http://api.weatherapi.com/v1/current.json?key={0}&q={1}";
  
  // Start is called before the first frame update
  void Start()
  {
    num_balls = 1;
    balls = new List<GameObject>();
    // for (int i = 0; i < 100; i++)
    // {
    //   AddBall();
    // }
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void AddBall()
  {
    if (num_balls >= max_balls)
    {
      print("TOO MANY BALLS: " + num_balls);
      return;
    }
    GameObject g = GameObject.Instantiate(sampleObject);
    SpriteRenderer m_SpriteRenderer;

    m_SpriteRenderer = g.GetComponent<SpriteRenderer>();

    double temp = GetTemperatureByZipcode();
    // double temp = 40;
    print("temp is: " + temp);

    // m_SpriteRenderer.color = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    m_SpriteRenderer.color = GetColorForTemperature(temp);
    Transform t = g.transform;
    var position = new Vector3(UnityEngine.Random.Range(-7.0f, 7.0f), UnityEngine.Random.Range(-3.0f, 3.0f), 0);

    t.position = position;
    num_balls++;
    print("ADDED BALLS: " + num_balls);

  }

  public void RemoveBall()
  {
    num_balls -= 1;
    print("DESTROYED BALL");
    print("num balls: " + num_balls);
  }

  private double GetTemperatureByZipcode()
  {
    double temperature = 45;
      using (HttpClient client = new HttpClient())
      {
          
          int zipcodeMin = 501;
          int zipcodeMax = 99950;
          System.Random r = new System.Random();
          
          int zipCode = r.Next(zipcodeMin, zipcodeMax);
          string szipCode = String.Format("{0:00000}", zipCode); 
          string url = string.Format(apiUrl, apiKey, szipCode);
          HttpResponseMessage response = client.GetAsync(url).Result;

          if (response.IsSuccessStatusCode)
          {
              string json = response.Content.ReadAsStringAsync().Result;
              JObject weatherData = JObject.Parse(json);
              temperature = weatherData["current"]["temp_f"].ToObject<double>();
              string condition = weatherData["current"]["condition"]["text"].ToString();
              print($"The temperature at zipcode {zipCode} is {temperature}°F with {condition}.");
          }
          
      }
    return temperature;
  }

  private Color GetColorForTemperature(double temp)
  {
      if (temp <= 0)
          return InterpolateColor(temp, -30, 0, (0, 0, 255), (0, 255, 255));  // Blue to cyan
      else if (temp > 0 && temp <= 50)
          return InterpolateColor(temp, 0, 10, (0, 255, 255), (0, 255, 0));  // Cyan to green
      else if (temp > 10 && temp <= 75)
          return InterpolateColor(temp, 10, 20, (0, 255, 0), (255, 255, 0)); // Green to yellow
      else if (temp > 20 && temp <= 80)
          return InterpolateColor(temp, 20, 30, (255, 255, 0), (255, 0, 0)); // Yellow to red
      else
          return InterpolateColor(temp, 30, 50, (255, 0, 0), (139, 0, 0));   // Red 
  }

  // Function to interpolate between two colors
  private Color InterpolateColor(double temp, double minTemp, double maxTemp, (int r, int g, int b) startColor, (int r, int g, int b) endColor)
  {
      double fraction = (temp - minTemp) / (maxTemp - minTemp);

      // Ensure fraction is between 0 and 1
      fraction = Math.Max(0, Math.Min(1, fraction));

      int r = (int)(startColor.r + fraction * (endColor.r - startColor.r));
      int g = (int)(startColor.g + fraction * (endColor.g - startColor.g));
      int b = (int)(startColor.b + fraction * (endColor.b - startColor.b));

      return new Color(r/255f, g/255f, b/255f); // Return the interpolated RGB color as a string
  }

  public void restart(){
    SceneManager.LoadScene("SampleScene");
  }
}
