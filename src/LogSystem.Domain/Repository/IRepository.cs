using LogSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Domain.Repository
{
    public interface IRepository
    {
        void SalvaLead(Leads leads);
        void Accepted(Leads leads);
        void Declined(Leads leads);
        IEnumerable<Leads> GetLeadsByStatus(int  status);


    }
}
