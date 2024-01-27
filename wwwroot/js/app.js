const express = require('express');
const axios = require('axios');
const bodyParser = require('body-parser');

const app = express();
const port = 3000;

// OpenWeatherMap API key
const api_key = 'c07c8914bb7e7a7be6b8c7dbd738a309';

const defaultCity = "London";

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.get('/', (req, res) => {
  res.send('Server is running.');
});

app.post('/get_weather', async (req, res) => {
  const city = req.body.city || defaultCity;

  try {
    const weatherData = await getWeatherData(city);
    res.json(weatherData);
  } catch (error) {
    console.error('Error fetching weather information:', error);
    res.status(500).json({ error: 'Error fetching weather information.' });
  }
});

const getWeatherData = async (city) => {
  try {
    const response = await axios.get('http://api.openweathermap.org/data/2.5/weather', {
      params: {
        q: city,
        appid: api_key,
        units: 'metric'
      }
    });

    const { weather, main } = response.data;
    const { main: mainWeather, temp: temperature, humidity } = main;

    return { main_weather: weather[0].main, temperature, humidity };
  } catch (error) {
    throw error;
  }
};

app.listen(port, () => {
  console.log(`Server is listening on port ${port}`);
});
