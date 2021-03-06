using FinanciallySmart.SettingsFolder;
using FinanciallySmart.SettingsFolder.BanksFolder;
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

namespace FinanciallySmart
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void viewBanksBtn_Click(object sender, RoutedEventArgs e)
        {
            settingsFrame.Content = new ViewBanks();
        }

        private void addBanksBtn_Click(object sender, RoutedEventArgs e)
        {
            settingsFrame.Content = new AddBanks();
        }

        private void transactionIdentifiersBtn_Click(object sender, RoutedEventArgs e)
        {
            settingsFrame.Content = new TransactionIdentifiers();
        }
    }
}
