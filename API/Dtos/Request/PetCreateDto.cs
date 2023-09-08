using Infrastructure.Models;

namespace API.Dtos.Request
{
    public class PetCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public int OwnerId { get; set; }
    }
}
