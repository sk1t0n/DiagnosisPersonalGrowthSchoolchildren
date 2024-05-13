using DiagnosisPersonalGrowthSchoolchildren.Core;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        private void TextChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            ButtonOpenDialog.IsEnabled = TextSheetName.Text.Length > 0 ? true : false;
        }

        private void ButtonOpenDialog_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".xlsx";
            dialog.Filter = "Excel (.xlsx)|*.xlsx";
            bool? resultDialog = dialog.ShowDialog();

            if (resultDialog == true)
            {
                try
                {
                    var excelHelper = new ExcelHelper();
                    var answers = excelHelper.GetDataFromExcel(dialog.FileName, TextSheetName.Text);
                    var handler = new HandlerOfResults();
                    var data = handler.CalculateResult(answers);

                    var newExcelFileName = "DiagnosisResult.xlsx";
                    excelHelper.DrawChart(newExcelFileName, data);

                    string messageBoxText = $"Файл {newExcelFileName} успешно сохранён!";
                    string caption = "Сохранение Excel файла";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Information;
                    MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }
                catch (NullReferenceException)
                {
                    string messageBoxText = $"Ошибка: неверное название листа в Excel файле!";
                    string caption = "Произошла ошибка";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                }

                Application.Current.Shutdown();
            }
        }
    }
}