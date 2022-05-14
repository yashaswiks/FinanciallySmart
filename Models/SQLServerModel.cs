using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciallySmart.Models
{
    internal class SQLServerModel
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["sQLServerConnectionString"].ConnectionString;

        /// <summary>
        /// Returns ConnectionString of the SQL Server.
        /// </summary>
        /// <returns>(string) Returns Connection String.</returns>
        public string GetConnectionString()
        {
            return connectionString;
        }

        public int AddBankEntry(BankModel bankDetails)
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO bank (bank_name, account_number) VALUES (@bankName, @accountNumber)";
                using(SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = sqlCon;
                    cmd.Parameters.Add("@bankName", SqlDbType.VarChar, 50).Value = bankDetails.BankName;
                    cmd.Parameters.Add("@accountNumber", SqlDbType.VarChar, 100).Value = bankDetails.AccountNumber;
                    sqlCon.Open();
                    int o = cmd.ExecuteNonQuery();
                    sqlCon.Close();
                    return o;
                }
            }
        }
    }
}
