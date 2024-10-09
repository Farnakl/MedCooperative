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
    /// Логика взаимодействия для PageAddPatient.xaml
    /// </summary>
    public partial class PageAddPatient : Page
    {
        public PageAddPatient()
        {
            InitializeComponent();
            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedValuePath = "id";
            CmbGender.ItemsSource = Connector.DBConnect.Gender.ToList();

        }

        private void TxbPolis_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string pattern = @"[^0-9+-,.]+";
            if (Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TxbName.Text == "" || CmbGender.Text == "" || TxbAddress.Text == "" || TxbPolis.Text == "" || DtpBirth.Text == "")
            {
                MessageBox.Show("Поля пусты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else

            {
                try
                {
                    Patient patient = new Patient()
                    {
                        Address = TxbAddress.Text,
                        Name = TxbName.Text,
                        Gender = CmbGender.SelectedItem as Gender,
                        Medical_policy = TxbPolis.Text,
                        Birthdate = DateTime.Parse(DtpBirth.Text)
                };

                    Connector.DBConnect.Patient.Add(patient);
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

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }
    }
}
