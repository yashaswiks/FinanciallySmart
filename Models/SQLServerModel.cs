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
        /// Call this method to add a new Transaction Identifier to the DB.
        /// Takes in the name of the Transaction Identifier as the Parameter.
        /// </summary>
        /// <param name="transactionIdentifierName">(string) Transaction Indentifier Name</param>
        /// <returns>Returns 1 if the operation is successful. </returns>
        public int AddTransactionIdentifier(string transactionIdentifierName)
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO code_value (code_value)" +
                    " VALUES (@codeValue)";
                using(SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = sqlCon;
                    cmd.Parameters.Add("@codeValue", SqlDbType.VarChar, 50).Value = transactionIdentifierName;
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

        /// <summary>
        /// Returns All Transaction Identifiers from the DB.
        /// Returns a DataTable Object comprising of all Transaction Indentifier Details.
        /// </summary>
        /// <returns>Returns all Transaction Indentifiers in a DataTable object. </returns>
        public DataTable GetAllTransactionIdentifiers()
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "SELECT * from code_value";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// This method is used to Edit Bank Details. 
        /// </summary>
        /// <param name="bank"></param>
        /// <returns>1 if the Operation was successful. </returns>
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

        /// <summary>
        /// Takes in SELECT Query Statement as Parameter 
        /// and returns DataTable comprising SELECT statement output. 
        /// </summary>
        /// <param name="query">(string) SELECT statement as a Parameter. </param>
        /// <returns>(DataTable) SELECT statement output.</returns>
        public DataTable ExecuteQuery(string query)
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.CommandType = CommandType.Text;
                    using(SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using(DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        public int AddJournalEntry(JournalEntryModel journalEntry)
        {
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string query = "INSERT dbo.journal_entry(transaction_type_id, amount, Notes, bank_id, date_of_transaction, date_of_entry, is_reversed) " +
                    "VALUES(@transactionTypeId, @amount, @notes, @bankId, @dateOfTransaction, @dateOfEntry, @isReversed); ";
                using(SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = sqlCon;
                    cmd.Parameters.Add("@transactionTypeId", SqlDbType.Int).Value = journalEntry.JournalEntryTypeId;
                    cmd.Parameters.Add("@amount", SqlDbType.Money).Value = journalEntry.Amount;
                    cmd.Parameters.Add("@notes", SqlDbType.VarChar, 500).Value = journalEntry.Notes;
                    cmd.Parameters.Add("@bankId", SqlDbType.Int).Value = journalEntry.BankID;
                    cmd.Parameters.Add("@dateOfTransaction", SqlDbType.Date).Value = journalEntry.DateOfTransaction;
                    cmd.Parameters.Add("@dateOfEntry", SqlDbType.DateTime).Value = journalEntry.DateOfEntry;
                    cmd.Parameters.Add("@isReversed", SqlDbType.Int).Value = journalEntry.IsReversed;
                    try
                    {
                        sqlCon.Open();
                        int o = cmd.ExecuteNonQuery();
                        sqlCon.Close();
                        return o;
                    }
                    catch(SqlException sQLEx)
                    {
                        System.Windows.MessageBox.Show(sQLEx.Message);
                    }
                }
            }
            return -1;

            
        }
    }
}
