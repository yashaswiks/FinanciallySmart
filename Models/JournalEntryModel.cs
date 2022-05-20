using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanciallySmart.Models
{
    internal class JournalEntryModel
    {
        public int JournalEntryTypeId { get; set; }
        public decimal Amount { get; set; }
        public int BankID { get; set; }

        public JournalEntryModel(int journalEntryTypeId, decimal amount, int bankID)
        {
            JournalEntryTypeId = journalEntryTypeId;
            Amount = amount;
            BankID = bankID;
        }
    }
}
