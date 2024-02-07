using LogSystem.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.Domain.Entities
{
    public class Leads
    {
        public int LeadId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Status LeadsStatus { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

    }
}
