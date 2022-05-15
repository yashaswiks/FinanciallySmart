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

        /// <summary>
        /// This Method Adds Bank Details to SQL Server. 
        /// Takes in BankDetails Class Parameter. 
        /// </summary>
        /// <param name="bankDetails">(BankModel) BankModel Parameter. </param>
        /// <returns>returns 1 if the operation was successful. </returns>
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

        /// <summary>
        /// Returns Details of all Banks from the DB. 
        /// Returns a DataTable comprising all the data from the DB. 
        /// </summary>
        /// <returns>Returns a DataTable.</returns>
        public DataTable GetBankDetails()
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "SELECT * from bank";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        public int EditBankDetails(BankModel bank)
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
                using (SqlCommand command = sqlCon.CreateCommand())
            {
                command.CommandText = "UPDATE bank " +
                    "SET bank_name = @bankName, account_number = @accountNumber " +
                    "WHERE id = @id";

                command.Parameters.AddWithValue("@bankName", bank.BankName);
                command.Parameters.AddWithValue("@accountNumber", bank.AccountNumber);
                command.Parameters.AddWithValue("@id", bank.Id);
                sqlCon.Open();
                int o = command.ExecuteNonQuery();
                sqlCon.Close();
                return o;
            }
        }
    }
}
