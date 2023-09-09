using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ClinicalRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int PetId { get; set; }
        [JsonIgnore]
        public Pet Pet { get; set; } = null!;
    }
}
