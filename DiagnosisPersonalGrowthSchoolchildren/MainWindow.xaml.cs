using DiagnosisPersonalGrowthSchoolchildren.Core;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace DiagnosisPersonalGrowthSchoolchildren
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            FakeUser.SaveAnswersToExcel("fake_user.xlsx");

            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".xlsx";
            dialog.Filter = "Excel (.xlsx)|*.xlsx";

            bool? resultDialog = dialog.ShowDialog();

            if (resultDialog == true)
            {
                var excelHelper = new ExcelHelper();
                var answers = excelHelper.GetDataFromExcel("fake_user.xlsx", "Sheet1"); // dialog.FileName

                var handler = new HandlerOfResults();
                var data = handler.CalculateResult(answers);

                var newExcelFileName = "file.xlsx";
                excelHelper.DrawChart(newExcelFileName, data);

                string messageBoxText = $"Файл {newExcelFileName} успешно сохранён!";
                string caption = "Сохранение Excel файла";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                Application.Current.Shutdown();
            }
        }
    }
}