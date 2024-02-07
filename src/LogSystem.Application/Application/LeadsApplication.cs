using LogSystem.Domain.Entities;
using LogSystem.Domain.Repository;
using System;
using System.Collections.Generic;

namespace LogSystem.Application.Application
{
    public class LeadsApplication : ILeadsApplication
    {
        private readonly IRepository _repository;

        public LeadsApplication(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

      
        public void SaveLead(Leads leads)
        {

            if (leads == null)
            {
                throw new ArgumentNullException(nameof(leads));
            }

            _repository.SalvaLead(leads);
        }
        public string Accpted(Leads leads)
        {
            if (leads.Price >= 500)
            {
                decimal discount = leads.Price * 0.10m;

                leads.Price -= discount;

                leads.Price = Math.Max(leads.Price, 0);
            }
            _repository.Accepted(leads);

            return SendEmailService(leads);
        }

        public void Declined(Leads leads)
        {
            _repository.Declined(leads);
        }

        public string SendEmailService(Leads leads)
        {
            string _emailServiceDataLog = @$"
                                        Email enviado com sucesso!
                                        Preço: {leads.Price}
                                        Categoria do Lead: {leads.Category}";
            return _emailServiceDataLog;
        }

        public IEnumerable<Leads> GetLeadsByStatus(int status)
        {
            return _repository.GetLeadsByStatus(status);
        }
    }
}
