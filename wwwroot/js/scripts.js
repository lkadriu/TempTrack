const apiKey = 'c07c8914bb7e7a7be6b8c7dbd738a309';


// Function to set the seasonal background images initially
function setSeasonalBackground() {
    const body = document.body;
    const currentDate = new Date();
    const currentMonth = currentDate.getMonth() + 1; // Months are zero-based in JavaScript

    // Based on the current month, set the seasonal background image
    if (currentMonth >= 3 && currentMonth <= 5) {
        body.className = 'spring-bg';
    } else if (currentMonth >= 6 && currentMonth <= 8) {
        body.className = 'summer-bg';
    } else if (currentMonth >= 9 && currentMonth <= 11) {
        body.className = 'autumn-bg';
    } else {
        body.className = 'winter-bg';
    }
}
function getWeather() {
    const city = document.getElementById('cityInput').value;

    if (city.trim() !== '') {
        fetch(`https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric`)
            .then(response => response.json())
            .then(data => {
                weatherData = {
                    city: data.name,
                    temperature: data.main.temp,
                    humidity: data.main.humidity,
                    condition: data.weather[0].main,
                };

                changeBackground(weatherData.condition);

                const weatherInfoDiv = document.getElementById('weatherInfo');
                weatherInfoDiv.innerHTML = `
                    <h2>${weatherData.city}</h2>
                    <p>Temperature: ${weatherData.temperature}°C</p>
                    <p>Humidity: ${weatherData.humidity}%</p>
                    <p>Condition: ${weatherData.condition}</p>
                `;

                const aboutButton = document.getElementById('about');
                aboutButton.addEventListener('click', showAdditionalContent);
            })
            .catch(error => {
                console.error('Error fetching weather data:', error);
                displayWeatherError();
            });
    } else {
        alert('Please enter a city name.');
    }
}

// Function to display error message
function displayWeatherError() {
    const weatherInfoDiv = document.getElementById('weatherInfo');
    weatherInfoDiv.innerHTML = '<p>Failed to fetch weather data. Please try again.</p>';
}
function setSeasonalBackground() {
    // Your existing setSeasonalBackground code...
}

// Function to display error message for weather
function displayWeatherError() {
    // Your existing displayWeatherError code...
}

// Function to fetch weather data
function getWeather() {
    // Your existing getWeather code...
}



// Initially set the seasonal background
setSeasonalBackground();

        