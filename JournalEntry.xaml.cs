using FinanciallySmart.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanciallySmart
{
    /// <summary>
    /// Interaction logic for JournalEntry.xaml
    /// </summary>
    public partial class JournalEntry : UserControl
    {
        public JournalEntry()
        {
            InitializeComponent();
            PopulatePage();
        }

        private void PopulatePage()
        {
            SQLServerModel sQLServer = new SQLServerModel();
            DataTable journalEntryTypesDt = new DataTable();
            DataTable bankDt = new DataTable();

            string query = "SELECT cv.id, " +
                "cv.code_value " +
                "FROM code_value cv " +
                "WHERE cv.code_value_classification = 1; ";
            journalEntryTypesDt = sQLServer.ExecuteQuery(query);
            journalEntryComboBox.ItemsSource = journalEntryTypesDt.DefaultView;
            journalEntryComboBox.DisplayMemberPath = "code_value";
            journalEntryComboBox.SelectedValuePath = "id";
            journalEntryComboBox.SelectedValue = "1";

            string bankComboBoxQuery = "SELECT " +
                "b.id, " +
                "b.bank_name " +
                "FROM bank b; ";
            bankDt = sQLServer.ExecuteQuery(bankComboBoxQuery);
            bankComboBox.ItemsSource = bankDt.DefaultView;
            bankComboBox.DisplayMemberPath = "bank_name";
            bankComboBox.SelectedValuePath = "id";


            overViewDebitGridTable.ItemsSource = null;
            overViewDebitGridTable.Items.Clear();
            overViewDebitGridTable.Items.Refresh();
            DataTable dt2 = new DataTable();
            dt2 = sQLServer.GetTotalDebitedAmountOfCurrentMonth();
            overViewDebitGridTable.ItemsSource = dt2.DefaultView;

        }

        private void addJournalEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            SQLServerModel sQLServer = new SQLServerModel();
            decimal amount; 
            
            if(journalEntryComboBox.SelectedValue != null 
                && bankComboBox.SelectedValue != null
                && notesTxtBox.Text != String.Empty
                && amountTxtBox.Text != String.Empty
                && decimal.TryParse(amountTxtBox.Text, out amount))
            {
                int journalEntryTypeId = Convert.ToInt32(journalEntryComboBox.SelectedValue);
                int bankId = Convert.ToInt32(bankComboBox.SelectedValue);
                string notes = notesTxtBox.Text;
                DateTime? dateOfTransaction = dateOfTransactionDatePicker.SelectedDate;

                JournalEntryModel journalEntry = new JournalEntryModel(journalEntryTypeId, amount, notes, bankId, dateOfTransaction,
                    DateTime.Now, 0);
                int o = sQLServer.AddJournalEntry(journalEntry);
                if(o==1)
                {
                    MessageBox.Show("Journal Entry has been recorded");
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Values.");
            }
        }
    }
}
