using Infrastructure.Models;

namespace API.Dtos.Request
{
    public class ClinicalRecordCreateDto
    {
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int PetId { get; set; }
    }
}
