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
    /// Логика взаимодействия для PageAnalyze.xaml
    /// </summary>
    public partial class PageAnalyze : Page
    {
        public PageAnalyze()
        {
            InitializeComponent();
            DataGridAnalize.ItemsSource = null;
            DataGridAnalize.ItemsSource = Connector.DBConnect.BookAnalysis.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
                Navigation.frameView.Navigate(new PageAddAnalyze());
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxbSearch.Text != "")
                {
                    string searchString = TxbSearch.Text.ToLower();

                    var itemsList = Connector.DBConnect.BookAnalysis.ToList();

                    //Ищем совпадения в таблице
                    var searchResults = itemsList.Where(item => item.Patient.Name.ToLower().Contains(searchString)).ToList();

                    //Заполняем таблицу записями, где есть совпадения
                    DataGridAnalize.ItemsSource = searchResults.ToList();
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
                for (int i = 0; i < DataGridAnalize.SelectedItems.Count; i++)
                {
                    BookAnalysis bookAnalysis = DataGridAnalize.SelectedItems[i] as BookAnalysis;
                    Connector.DBConnect.BookAnalysis.Remove(bookAnalysis);
                }

                Connector.DBConnect.SaveChanges();
                MessageBox.Show("Данные успешно удалены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridAnalize.ItemsSource = null;
                DataGridAnalize.ItemsSource = Connector.DBConnect.BookAnalysis.ToList();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message.ToString(), "Критическая обработка");
            }
        }

        private void BtnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.Navigate(new PageEditAnalyze((sender as Button).DataContext as BookAnalysis));

        }

        private void TxbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TxbSearch.Text = "";
        }
    }
}
