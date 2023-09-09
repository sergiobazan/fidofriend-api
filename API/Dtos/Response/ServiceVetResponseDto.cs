using Infrastructure.Models;

namespace API.Dtos.Response
{
    public class ServiceVetResponseDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int VetId { get; set; }
        public int ServiceId { get; set; }
    }
}
