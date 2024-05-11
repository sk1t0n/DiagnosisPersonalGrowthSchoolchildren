using System.IO;
using System.Text.Json;
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
            
            var answers = FakeUser.GetAnswers();

            using var file = File.CreateText("fake_answers.txt");
            file.WriteLine(JsonSerializer.Serialize(answers));

            var handler = new HandlerOfResults();
            handler.CalculateByScales(new Scales(), answers);
        }
    }
}