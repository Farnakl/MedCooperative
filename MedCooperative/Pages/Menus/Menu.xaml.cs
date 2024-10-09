using MedCooperative.Model;
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
using static MedCooperative.Classes.Navigator;

namespace MedCooperative.Pages.Menus
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void GoToProvidersPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageAnalyze());
        }

        private void GoToTablePage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageDoctors());
        }

        private void GoToPacientePage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PagePatient());
        }
    }
}
