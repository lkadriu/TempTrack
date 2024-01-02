namespace TempTrackApp.Models
{
    public partial class KategoriteEmotit
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string? Pershkrimi { get; set; }
        public int? TemperaturaMin { get; set; }
        public int? TemperaturaMax { get; set; }
    }
}
