using System;
using System.Collections.Generic;

namespace TempTrackApp.Models
{
    public partial class Klienti
    {
        public int Id { get; set; }
        public int ClientCode { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
