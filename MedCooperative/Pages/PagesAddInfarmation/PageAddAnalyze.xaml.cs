using MedCooperative.Classes;
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
using System.Xml.Linq;

namespace MedCooperative.Pages.PagesAddInfarmation
{
    /// <summary>
    /// Логика взаимодействия для PageAddAnalyze.xaml
    /// </summary>
    public partial class PageAddAnalyze : Page
    {
        public PageAddAnalyze()
        {
            InitializeComponent();
            CmbDoctor.DisplayMemberPath = "Name";
            CmbDoctor.SelectedValuePath = "id";
            CmbDoctor.ItemsSource = Connector.DBConnect.Doctors.ToList();

            CmbDiagnoz.DisplayMemberPath = "Name";
            CmbDiagnoz.SelectedValuePath = "id";
            CmbDiagnoz.ItemsSource = Connector.DBConnect.Diagnosis.ToList();

            CmbPatient.DisplayMemberPath = "Name";
            CmbPatient.SelectedValuePath = "id";
            CmbPatient.ItemsSource = Connector.DBConnect.Patient.ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (CmbDoctor.Text == "" || CmbDiagnoz.Text == "" || CmbPatient.Text == "" || TxbNotes.Text == "" )
            {
                MessageBox.Show("Поля пусты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else

            {
                try
                {
                    BookAnalysis bookAnalysis = new BookAnalysis()
                    {
                       
                        Description = TxbNotes.Text,
                        Doctors = CmbDoctor.SelectedItem as Doctors,
                        Patient = CmbPatient.SelectedItem as Patient,
                        Diagnosis = CmbDiagnoz.SelectedItem as Diagnosis
                    };

                    Connector.DBConnect.BookAnalysis.Add(bookAnalysis);
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

    }
}
