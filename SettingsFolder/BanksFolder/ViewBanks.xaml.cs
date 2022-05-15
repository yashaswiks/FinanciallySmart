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

namespace FinanciallySmart.SettingsFolder.BanksFolder
{
    /// <summary>
    /// Interaction logic for ViewBanks.xaml
    /// </summary>
    public partial class ViewBanks : Page
    {
        public ViewBanks()
        {
            InitializeComponent();
            SQLServerModel sQLServer = new SQLServerModel();
            DataTable dt = new DataTable("Banks");
            dt = sQLServer.GetBankDetails();
            viewBanksDataGridView.ItemsSource = dt.DefaultView;
        }

        private void editBanksBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                int bankId = Convert.ToInt32(dataRowView[0]);
                string bankName = dataRowView[1].ToString();
                string bankCode = dataRowView[2].ToString();

                BankModel editBank = new BankModel(bankId, bankName, bankCode);
                EditBanksWindow editBanksWindow = new EditBanksWindow(editBank);
                editBanksWindow.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
