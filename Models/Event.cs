using System;
using System.Collections.Generic;

namespace TempTrackApp.Models
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
        public string? Location { get; set; }
    }
}
