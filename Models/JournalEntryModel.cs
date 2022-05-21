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
        public string Notes { get; set; }
        public int BankID { get; set; }
        public DateTime? DateOfTransaction { get; set; }
        public DateTime DateOfEntry { get; set; }
        public int IsReversed { get; set; }

        public JournalEntryModel(int journalEntryTypeId, decimal amount, string notes, int bankID, 
            DateTime? dateOfTransaction, DateTime dateOfEntry, int isReversed)
        {
            JournalEntryTypeId = journalEntryTypeId;
            Amount = amount;
            Notes = notes ?? throw new ArgumentNullException(nameof(notes));
            BankID = bankID;
            DateOfTransaction = dateOfTransaction;
            DateOfEntry = dateOfEntry;
            IsReversed = isReversed;
        }
    }
}
