using Infrastructure.Models;

namespace API.Dtos.Request
{
    public class MeetingCreateDto
    {
        public DateTime Date { get; set; }
        public bool Finish { get; set; } = false;
        public int VetId { get; set; }
        public int ClientId { get; set; }
    }
}
