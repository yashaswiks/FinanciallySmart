using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciallySmart.Models
{
    internal class SQLServerModel
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["sQLServerConnectionString"].ConnectionString;

        public string GetConnectionString()
        {
            return connectionString;
        }
    }
}
