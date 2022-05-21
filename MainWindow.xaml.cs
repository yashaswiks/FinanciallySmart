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

namespace FinanciallySmart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JournalEntry journalEntry = new JournalEntry();
        public MainWindow()
        {
            InitializeComponent();
            mainWindowFrame.Navigate(journalEntry);
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            Settings settingWindow = new Settings();
            settingWindow.Show();
        }

        private void viewTransactions_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Navigate(new ViewJournalEntry());
        }

        private void addTransactions_Click(object sender, RoutedEventArgs e)
        {
            mainWindowFrame.Navigate(journalEntry);
        }
    }
}
