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

        }

        private void addJournalEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal amount; 
            
            if(journalEntryComboBox.SelectedValue != null 
                && bankComboBox.SelectedValue != null
                && amountTxtBox.Text != String.Empty
                && decimal.TryParse(amountTxtBox.Text, out amount))
            {

                JournalEntryModel newJournalEntry = new JournalEntryModel(Convert.ToInt32(journalEntryComboBox.SelectedValue),
                    amount, Convert.ToInt32(bankComboBox.SelectedValue));
            }
            else
            {
                MessageBox.Show("Enter Valid Values.");
            }
        }
    }
}
