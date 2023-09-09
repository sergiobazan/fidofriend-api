using Infrastructure.Models;

namespace API.Dtos.Response
{
    public class PetResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public ICollection<ClinicalRecord> ClinicalRecords { get; set; } = new List<ClinicalRecord>();
    }
}
