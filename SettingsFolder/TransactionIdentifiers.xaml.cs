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

namespace FinanciallySmart.SettingsFolder
{
    /// <summary>
    /// Interaction logic for TransactionIdentifiers.xaml
    /// </summary>
    public partial class TransactionIdentifiers : Page
    {
        public TransactionIdentifiers()
        {
            InitializeComponent();
            PopulateTransactionIdentifierTable();
        }

        private void addIdentifierBtn_Click(object sender, RoutedEventArgs e)
        {
            if (newIdentifierTxtBox.Text != String.Empty)
            {
                SQLServerModel sQLServer = new SQLServerModel();
                string transactionIdentifier = newIdentifierTxtBox.Text;
                int o = sQLServer.AddTransactionIdentifier(transactionIdentifier);
                if(o == 1)
                {
                    PopulateTransactionIdentifierTable();
                }
            }
            else MessageBox.Show("Enter a valid Transaction Identifier");
        }

        private void PopulateTransactionIdentifierTable()
        {
            try
            {
                transactionIdentifersGridView.ItemsSource = null;
                transactionIdentifersGridView.Items.Clear();
                transactionIdentifersGridView.Items.Refresh();

                SQLServerModel sQLServer = new SQLServerModel();
                DataTable dt = new DataTable();
                dt = sQLServer.GetAllTransactionIdentifiers();
                transactionIdentifersGridView.ItemsSource = dt.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
