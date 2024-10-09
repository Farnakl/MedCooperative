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

namespace MedCooperative.Pages.PageEditInformation
{
    /// <summary>
    /// Логика взаимодействия для PageEditPatient.xaml
    /// </summary>
    public partial class PageEditPatient : Page
    {
        private int patientId;
        public PageEditPatient(Patient patient)
        {
            InitializeComponent();

            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedValuePath = "id";
            CmbGender.ItemsSource = Connector.DBConnect.Gender.ToList();
            CmbGender.Text = patient.Gender.Name.ToString();

            
            DtpBirth.Text = patient.Birthdate.ToString();

            TxbPolis.Text = patient.Medical_policy.ToString();

            TxbAddress.Text = patient.Address.ToString();

            TxbName.Text = patient.Name.ToString();

            patientId = patient.Id;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
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
            if (TxbName.Text == "" || CmbGender.Text == "" || DtpBirth.Text == "" || TxbPolis.Text == "" || TxbAddress.Text == "")
            {
                MessageBox.Show("Поля пусты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else

            {
                Anayatov_MedicineEntities context = new Anayatov_MedicineEntities();
                var patient = context.Patient.Where(c => c.Id == patientId).FirstOrDefault();

                patient.Name = TxbName.Text;
                patient.Birthdate = DateTime.Parse(DtpBirth.Text); ;
                patient.Medical_policy = TxbPolis.Text;
                patient.Address=TxbAddress.Text;
                patient.Name = TxbName.Text;

                context.SaveChanges();

                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.frameView.GoBack();
            }
        }
    }
}
