using System;
using System.Collections.Generic;

namespace TempTrackApp.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
