namespace PractiseHotel.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public bool IsAvailible { get; set; } = false;
    }
}
