using System;
using System.Collections.Generic;

namespace TempTrackApp.Models
{
    public partial class Forecast
    {
        public int ForecastId { get; set; }
        public string City { get; set; } = null!;
        public double Temperature { get; set; }
        public DateTime ForecastDate { get; set; }
    }
}
