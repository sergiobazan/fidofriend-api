using Infrastructure.Models;

namespace API.Dtos.Response
{
    public class ClinicalRecordResponseDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int PetId { get; set; }
        public Pet Pet { get; set; } = null!;
    }
}
