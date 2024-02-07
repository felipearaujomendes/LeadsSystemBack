using LogSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.Application.Application
{
    public interface ILeadsApplication
    {
        IEnumerable<Leads> GetLeadsByStatus(int status);
        void SaveLead (Leads leads);
        string Accpted (Leads leads);
        void Declined (Leads leads);
        string SendEmailService (Leads leads);
    }
}
