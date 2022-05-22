using FinanciallySmart.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// Interaction logic for ViewJournalEntry.xaml
    /// </summary>
    public partial class ViewJournalEntry : Page
    {
        public ViewJournalEntry()
        {
            InitializeComponent();
            clearDataGridView();
            PopulateJournalEntries();
        }

        private void editJournalEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLServerModel sQLServer = new SQLServerModel();
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                int journalEntryId = Convert.ToInt32(dataRowView[0]);
                int o = sQLServer.ReverseJournalEntry(journalEntryId);
                if(o==1)
                {
                    PopulateJournalEntries();
                }
                else
                {
                    MessageBox.Show("The Operation has failed");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulateJournalEntries()
        {
            journalEntriesGridView.ItemsSource = null;
            journalEntriesGridView.Items.Clear();
            journalEntriesGridView.Items.Refresh();
            SQLServerModel sQLServer = new SQLServerModel();
            DataTable dt = new DataTable("journalEntries");
            dt = sQLServer.GetJournalEntries();
            journalEntriesGridView.ItemsSource = dt.DefaultView;
        }

        private void viewTransactionsBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO Add Proper Validations here. 
            SQLServerModel sQLServer = new SQLServerModel();
            if (searchByIdTxtBox.Text == String.Empty)
            {
                DateTime? startDate = startDatePicker.SelectedDate;
                DateTime? endDate = endDatePicker.SelectedDate;
                DataTable dt = sQLServer.GetJournalEntriesBetweenDates(startDate, endDate);
                if (dt.Rows.Count > 0)
                {
                    clearDataGridView();
                    journalEntriesGridView.ItemsSource = dt.DefaultView;
                }
            }
            else if(searchByIdTxtBox.Text != String.Empty)
            {
                int id = Convert.ToInt32(searchByIdTxtBox.Text);
                DataTable dt = sQLServer.GetJournalEntryById(id);
                if(dt.Rows.Count > 0)
                {
                    clearDataGridView();
                    journalEntriesGridView.ItemsSource = dt.DefaultView;
                }
            }
        }

        private void searchByIdTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(searchByIdTxtBox.Text != String.Empty)
            {
                startDatePicker.IsEnabled = false;
                endDatePicker.IsEnabled = false;
            }
            else if(searchByIdTxtBox.Text == String.Empty)
            {
                startDatePicker.IsEnabled = true;
                endDatePicker.IsEnabled= true;
            }
        }

        private void clearDataGridView()
        {
            journalEntriesGridView.ItemsSource = null;
            journalEntriesGridView.Items.Clear();
            journalEntriesGridView.Items.Refresh();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            clearDataGridView();
            PopulateJournalEntries();
        }
    }
}
