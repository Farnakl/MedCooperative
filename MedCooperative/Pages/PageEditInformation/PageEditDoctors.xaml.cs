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
    /// Логика взаимодействия для PageEditDoctors.xaml
    /// </summary>
    public partial class PageEditDoctors : Page
    {
        private int doctorsId;
        public PageEditDoctors(Doctors doctors)
        {
            InitializeComponent();

            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedValuePath = "id";
            CmbGender.ItemsSource = Connector.DBConnect.Gender.ToList();
            CmbGender.Text = doctors.Gender.Name.ToString();

            CmbSpeciality.DisplayMemberPath = "Name";
            CmbSpeciality.SelectedValuePath = "id";
            CmbSpeciality.ItemsSource = Connector.DBConnect.Category.ToList();
            CmbSpeciality.Text = doctors.Category.Name.ToString();

            CmbStatus.DisplayMemberPath = "Name";
            CmbStatus.SelectedValuePath = "id";
            CmbStatus.ItemsSource = Connector.DBConnect.Status.ToList();
            CmbStatus.Text = doctors.Status.Name.ToString();

            TxbCabinet.Text = doctors.Cabinet.ToString();

            TxbName.Text = doctors.Name.ToString();

            doctorsId = doctors.Id;
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
                Anayatov_MedicineEntities context = new Anayatov_MedicineEntities();
                var doctors = context.Doctors.Where(c => c.Id == doctorsId).FirstOrDefault();

                doctors.Cabinet = TxbCabinet.Text;
                doctors.Id_status = (CmbStatus.SelectedItem as Status).Id;
                doctors.Id_category = (CmbSpeciality.SelectedItem as Category).Id;
                doctors.Id_gender = (CmbGender.SelectedItem as Gender).Id;
                doctors.Name = TxbName.Text;

                context.SaveChanges();

                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.frameView.GoBack();
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
