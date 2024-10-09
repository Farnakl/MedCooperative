using MedCooperative.Classes;
using MedCooperative.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MedCooperative.Pages.PagesAddInfarmation
{
    /// <summary>
    /// Логика взаимодействия для PageAddDoctors.xaml
    /// </summary>
    public partial class PageAddDoctors : Page
    {
        public PageAddDoctors()
        {
            InitializeComponent();
            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedValuePath = "id";
            CmbGender.ItemsSource = Connector.DBConnect.Gender.ToList();

            CmbSpeciality.DisplayMemberPath = "Name";
            CmbSpeciality.SelectedValuePath = "id";
            CmbSpeciality.ItemsSource = Connector.DBConnect.Category.ToList();

            CmbStatus.DisplayMemberPath = "Name";
            CmbStatus.SelectedValuePath = "id";
            CmbStatus.ItemsSource = Connector.DBConnect.Status.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == "" || CmbGender.Text == "" || CmbSpeciality.Text == "" || TxbCabinet.Text == "" || CmbStatus.Text == "")
            {
                MessageBox.Show("Поля пусты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else

            {
                try
                {
                    Doctors doctors= new Doctors()
                    {
                        Cabinet = TxbCabinet.Text,
                        Name = TxbName.Text,
                        Gender = CmbGender.SelectedItem as Gender,
                        Status = CmbStatus.SelectedItem as Status,
                        Category = CmbSpeciality.SelectedItem as Category
                    };

                    Connector.DBConnect.Doctors.Add(doctors);
                    Connector.DBConnect.SaveChanges();
                    MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    Navigation.frameView.GoBack();
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString(), "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }


            }
        }

        private void TxbCabinet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }
    }
}
