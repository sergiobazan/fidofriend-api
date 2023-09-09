using Infrastructure.Models;

namespace API.Dtos.Request
{
    public class ServiceVetCreateDto
    {
        public decimal Price { get; set; }
        public int VetId { get; set; }
        public int ServiceId { get; set; }
    }
}
