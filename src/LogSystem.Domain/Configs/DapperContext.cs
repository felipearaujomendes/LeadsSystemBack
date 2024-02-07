using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace LogSystem.Domain.Configs
{
    public class DapperContext:IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Data Source=SQL8006.site4now.net;Initial Catalog=db_aa0b15_seguradora;User Id=db_aa0b15_seguradora_admin;Password=Socialmente123!!");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection("Data Source=SQL8006.site4now.net;Initial Catalog=db_aa0b15_seguradora;User Id=db_aa0b15_seguradora_admin;Password=Socialmente123!!");
    }
}
