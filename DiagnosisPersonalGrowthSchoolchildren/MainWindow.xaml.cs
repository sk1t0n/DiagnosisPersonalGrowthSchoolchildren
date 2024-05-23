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

        private void ButtonOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".xlsx";
            dialog.Filter = "Excel (.xlsx)|*.xlsx";
            bool? dialogResult = dialog.ShowDialog();

            if (dialogResult == true)
            {
                var excelHelper = new ExcelHelper();
                var newExcelFileName = "DiagnosisResults.xlsx";

                if (File.Exists(newExcelFileName))
                {
                    File.Delete(newExcelFileName);
                }

                var data = excelHelper.CalculateResult(dialog.FileName);
                excelHelper.DrawCharts(newExcelFileName, data);

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