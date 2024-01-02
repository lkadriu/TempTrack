namespace TempTrackApp.Models
{
    public partial class NiveletEere
    {
        public int Id { get; set; }
        public string Emri { get; set; } = null!;
        public string? Pershkrimi { get; set; }
        public int? ShpejtesiaMin { get; set; }
        public int? ShpejtesiaMax { get; set; }
    }
}
