using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;

        public ICollection<ClinicalRecord> ClinicalRecords { get; set; } = new List<ClinicalRecord>();
    }
}
