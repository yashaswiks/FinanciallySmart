using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciallySmart.Models
{
    public class BankModel
    {
        public int Id { get; set; }
        public String BankName { get; set; }
        public String AccountNumber { get; set; }

        public BankModel(string bankName, string accountNumber)
        {
            BankName = bankName ?? throw new ArgumentNullException(nameof(bankName));
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
        }

        public BankModel(int id, string bankName, string accountNumber)
        {
            Id = id;
            BankName = bankName ?? throw new ArgumentNullException(nameof(bankName));
            AccountNumber = accountNumber ?? throw new ArgumentNullException(nameof(accountNumber));
        }
    }
}
