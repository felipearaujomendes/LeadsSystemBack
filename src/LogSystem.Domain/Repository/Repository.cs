using Dapper;
using LogSystem.Domain.Configs;
using LogSystem.Domain.Entities;
using LogSystem.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LogSystem.Domain.Repository
{
    public class Repository : IRepository
    {
        private readonly IDapperContext _context;

        public Repository(IDapperContext context)
        {
            _context = context;
        }

        public void SalvaLead(Leads leads)
        {
            var query = "INSERT INTO Leads (DateCreated, Suburb, Category, Description, Price, LeadsStatus) " +
                        "VALUES (@DateCreated, @Suburb, @Category, @Description, @Price, @LeadsStatus)";

            var parameters = new DynamicParameters();
            parameters.Add("DateCreated", leads.DateCreated, DbType.DateTime);
            parameters.Add("Suburb", leads.Suburb, DbType.String);
            parameters.Add("Category", leads.Category, DbType.String);
            parameters.Add("Description", leads.Description, DbType.String);
            parameters.Add("Price", leads.Price, DbType.Decimal);
            parameters.Add("LeadsStatus", (int)leads.LeadsStatus, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void Accepted(Leads leads)
        {
            leads.LeadsStatus = Status.Accept;

            var query = "UPDATE Leads SET Price = @Price, LeadsStatus = @LeadsStatus WHERE LeadId = @LeadId";
            var parameters = new DynamicParameters();

            parameters.Add("Price", leads.Price, DbType.Decimal);
            parameters.Add("LeadsStatus", (int)leads.LeadsStatus, DbType.Int32);
            parameters.Add("LeadId", leads.LeadId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void Declined(Leads leads)
        {
            leads.LeadsStatus = Status.Declined;

            // Atualiza a entrada no banco de dados
            var query = "UPDATE Leads SET LeadsStatus = @LeadsStatus WHERE LeadId = @LeadId";
            var parameters = new DynamicParameters();

            parameters.Add("LeadsStatus", (int)leads.LeadsStatus, DbType.Int32);
            parameters.Add("LeadId", leads.LeadId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public IEnumerable<Leads> GetLeadsByStatus(int status)
        {
            var query = "SELECT * FROM Leads WHERE LeadsStatus = @Status";

            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Leads>(query, new { Status = status });
            }
        }
    }
}
