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

            var handler = new HandlerOfResults();
            var result = handler.CalculateResult(answers);
        }
    }
}