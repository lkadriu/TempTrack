using System;
using System.Collections.Generic;

namespace TempTrackApp.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
