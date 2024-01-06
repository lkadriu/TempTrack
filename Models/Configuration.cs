using System;
using System.Collections.Generic;

namespace TempTrackApp.Models
{
    public partial class Configuration
    {
        public int ConfigId { get; set; }
        public string? ConfigName { get; set; }
        public string? ConfigValue { get; set; }
    }
}
