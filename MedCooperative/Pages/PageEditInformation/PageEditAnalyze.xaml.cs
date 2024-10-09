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
using System.Xml.Linq;
using static MedCooperative.Classes.Navigator;

namespace MedCooperative.Pages.PageEditInformation
{
    /// <summary>
    /// Логика взаимодействия для PageEditAnalyze.xaml
    /// </summary>
    public partial class PageEditAnalyze : Page
    {
        private int bookAnalysisId;
        public PageEditAnalyze(BookAnalysis bookAnalysis)
        {
            InitializeComponent();
            CmbDoctor.DisplayMemberPath = "Name";
            CmbDoctor.SelectedValuePath = "id";
            CmbDoctor.ItemsSource = Connector.DBConnect.Doctors.ToList();
            CmbDoctor.Text = bookAnalysis.Doctors.Name.ToString();

            CmbDiagnoz.DisplayMemberPath = "Name";
            CmbDiagnoz.SelectedValuePath = "id";
            CmbDiagnoz.ItemsSource = Connector.DBConnect.Diagnosis.ToList();
            CmbDiagnoz.Text = bookAnalysis.Diagnosis.Name.ToString();

            CmbPatient.DisplayMemberPath = "Name";
            CmbPatient.SelectedValuePath = "id";
            CmbPatient.ItemsSource = Connector.DBConnect.Patient.ToList();
            CmbPatient.Text = bookAnalysis.Patient.Name.ToString();

            TxbNotes.Text = bookAnalysis.Description.ToString();

            bookAnalysisId = bookAnalysis.Id;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frameView.GoBack();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (CmbDoctor.Text == "" || CmbDiagnoz.Text == "" || CmbPatient.Text == "" || TxbNotes.Text == "")
            {
                MessageBox.Show("Поля пусты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else

            {
                Anayatov_MedicineEntities context = new Anayatov_MedicineEntities();
                var analize = context.BookAnalysis.Where(c => c.Id == bookAnalysisId).FirstOrDefault();

                
                analize.Id_Diagnosis = (CmbDiagnoz.SelectedItem as Diagnosis).Id;
                analize.Id_Patient = (CmbPatient.SelectedItem as Patient).Id;
                analize.Id_Doctor = (CmbDoctor.SelectedItem as Doctors).Id;
                analize.Description = TxbNotes.Text;

                context.SaveChanges();

                MessageBox.Show("Данные успешно изменены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Navigation.frameView.GoBack();
            }
        }
    }
}
