using System;
using System.Collections.Generic;

namespace TempTrackApp.Models
{
    public partial class Map
    {
        public int MapId { get; set; }
        public string Name { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
