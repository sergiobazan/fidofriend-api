using Infrastructure.Models;

namespace API.Dtos.Response
{
    public class MeetingResponseDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Finish { get; set; }
        public int VetId { get; set; }
        public int ClientId { get; set; }
    }
}
