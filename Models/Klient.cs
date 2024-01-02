namespace TempTrackApp.Models
{
    public partial class Klient
    {
        public int Id { get; set; }
        public int ClientCode { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
