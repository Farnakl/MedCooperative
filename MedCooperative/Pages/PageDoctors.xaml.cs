using MedCooperative.Classes;
using MedCooperative.Model;
using MedCooperative.Pages.PageEditInformation;
using MedCooperative.Pages.PagesAddInfarmation;
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

namespace MedCooperative.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageDoctors.xaml
    /// </summary>
    public partial class PageDoctors : Page
    {
        public PageDoctors()
        {
            InitializeComponent();
            DataGridDoctor.ItemsSource = null;
            DataGridDoctor.ItemsSource = Connector.DBConnect.Doctors.ToList();
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageEditDoctors((sender as Button).DataContext as Doctors));
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbSearch.Text != "")
                {
                    string searchString = TxbSearch.Text.ToLower();

                    var itemsList = Connector.DBConnect.Doctors.ToList();

                    //Ищем совпадения в таблице
                    var searchResults = itemsList.Where(item => item.Name.ToLower().Contains(searchString)).ToList();

                    //Заполняем таблицу записями, где есть совпадения
                    DataGridDoctor.ItemsSource = searchResults.ToList();
                }
                else
                {
                    MessageBox.Show("Вы ничего не ввели", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < DataGridDoctor.SelectedItems.Count; i++)
                {
                    Doctors doctors = DataGridDoctor.SelectedItems[i] as Doctors;
                    Connector.DBConnect.Doctors.Remove(doctors);
                }

                Connector.DBConnect.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridDoctor.ItemsSource = null;
                DataGridDoctor.ItemsSource = Connector.DBConnect.Doctors.ToList();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageAddDoctors());
        }

        private void TxbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxbSearch.Text = "";
        }
    }
}
