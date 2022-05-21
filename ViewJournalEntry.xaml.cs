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
            SQLServerModel sQLServer = new SQLServerModel();
            DataTable dt = new DataTable("journalEntries");
            dt = sQLServer.GetJournalEntries();
            journalEntriesGridView.ItemsSource = dt.DefaultView;
        }

        private void editJournalEntryBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;

            }
            */
        }
    }
}
