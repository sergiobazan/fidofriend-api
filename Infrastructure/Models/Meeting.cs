using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Finish { get; set; }
        public int VetId { get; set; }
        public User Vet { get; set; } = null!;
        public int ClientId { get; set; }
        public User Client { get; set; } = null!;
    }
}
