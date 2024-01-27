import React, { useState } from 'react';
import './App.css';

function App() {
  const [city, setCity] = useState('');
  const [weatherData, setWeatherData] = useState(null);

  const apiKey = 'c07c8914bb7e7a7be6b8c7dbd738a309';

  const getWeather = () => {
    if (city.trim() !== '') {
      fetch(`https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric`)
        .then(response => response.json())
        .then(data => {
          setWeatherData({
            city: data.name,
            temperature: data.main.temp,
            humidity: data.main.humidity,
            condition: data.weather[0].main,
          });
        })
        .catch(error => {
          console.error('Error fetching weather data:', error);
        });
    } else {
      alert('Please enter a city name.');
    }
  };

  return (
    <div className="App">
      <div className="container">
        <div className="header">
          <h1 className="title">Weather App</h1>
          <input
            type="text"
            value={city}
            onChange={e => setCity(e.target.value)}
            placeholder="Enter city name"
          />
          <button onClick={getWeather} className="search-button">
            Search
          </button>
        </div>
        {weatherData && (
          <div className="weather-container">
            <h2>{weatherData.city}</h2>
            <p>Temperature: {weatherData.temperature}°C</p>
            <p>Humidity: {weatherData.humidity}%</p>
            <p>Condition: {weatherData.condition}</p>
          </div>
        )}
      </div>
    </div>
  );
}

export default App;
