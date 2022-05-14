using FinanciallySmart.Models;
using System;
using System.Collections.Generic;
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

namespace FinanciallySmart.SettingsFolder.BanksFolder
{
    /// <summary>
    /// Interaction logic for AddBanks.xaml
    /// </summary>
    public partial class AddBanks : Page
    {
        public AddBanks()
        {
            InitializeComponent();
        }

        private void addBankBtn_Click(object sender, RoutedEventArgs e)
        {
            // string? bankName = bankNameTxtBox.Text != String.Empty ? bankNameTxtBox.Text : null;
            string bankName = String.Empty;
            string accountNumber = String.Empty;

            if (bankNameTxtBox.Text != String.Empty)
                bankName = bankNameTxtBox.Text;
            else MessageBox.Show("Please Enter Bank Name.");

            if (accountNumberTxtBox.Text != String.Empty)
                accountNumber = accountNumberTxtBox.Text;
            else MessageBox.Show("Enter Bank Account Details.");

            if(bankName != String.Empty && accountNumber != String.Empty)
            {
                SQLServerModel sQLServer = new SQLServerModel();
                BankModel bankDetails = new BankModel(bankName, accountNumber);
                int o = sQLServer.AddBankEntry(bankDetails);
                if (o == 1)
                    MessageBox.Show("The Bank has been added.");
                else MessageBox.Show("The Operation has failed.");
            }
                
        }
    }
}
