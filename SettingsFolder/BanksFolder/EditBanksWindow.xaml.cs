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
using System.Windows.Shapes;

namespace FinanciallySmart.SettingsFolder.BanksFolder
{
    /// <summary>
    /// Interaction logic for EditBanksWindow.xaml
    /// </summary>
    public partial class EditBanksWindow : Window
    {
        public EditBanksWindow()
        {
            InitializeComponent();
        }

        public EditBanksWindow(BankModel bank)
        {
            InitializeComponent();

            editBankLabel.Content = bank.BankName;
            idContentLabel.Content = bank.Id;
            bankNameTxtBox.Text = bank.BankName;
            bankAccountNumberTxtBox.Text = bank.AccountNumber;

        }

        private void editBankBtn_Click(object sender, RoutedEventArgs e)
        {
            SQLServerModel sQLServer = new SQLServerModel();
            int bankId = Convert.ToInt32(idContentLabel.Content);
            string bankName = bankNameTxtBox.Text;
            string bankAccountNumber = bankAccountNumberTxtBox.Text;
            BankModel bankDetails = new BankModel(bankId, bankName, bankAccountNumber);
            int o = sQLServer.EditBankDetails(bankDetails);
        }
    }
}
