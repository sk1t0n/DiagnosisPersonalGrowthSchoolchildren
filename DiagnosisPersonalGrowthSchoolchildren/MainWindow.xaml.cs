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
            bool? resultDialog = dialog.ShowDialog();

            if (resultDialog == true)
            {
                var excelHelper = new ExcelHelper();
                var newExcelFileName = "DiagnosisResults.xlsx";

                if (File.Exists(newExcelFileName))
                {
                    File.Delete(newExcelFileName);
                }

                var sheetIndex = 1;
                var handler = new HandlerOfResults();

                while (true)
                {
                    try
                    {
                        var sheetName = $"Лист{sheetIndex}";
                        sheetIndex++;
                        var answers = excelHelper.GetDataFromExcel(dialog.FileName, sheetName);
                        var data = handler.CalculateResult(answers);
                        excelHelper.DrawChart(newExcelFileName, sheetName, data);
                    }
                    catch (NullReferenceException)
                    {
                        break;
                    }
                }

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