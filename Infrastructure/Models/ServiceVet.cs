using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ServiceVet
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int VetId { get; set; }
        public User Vet { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
