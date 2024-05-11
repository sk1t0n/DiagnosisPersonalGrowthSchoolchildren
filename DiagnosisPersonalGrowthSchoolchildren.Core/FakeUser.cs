using OfficeOpenXml;

namespace DiagnosisPersonalGrowthSchoolchildren
{
    public class FakeUser
    {
        public static int[] GetAnswers()
        {
            var answers = new int[91];
            var random = new Random();

            for (var i = 0; i < answers.Length; i++)
            {
                answers[i] = random.Next(-4, 5);
            }

            return answers;
        }

        public static void SaveAnswersToExcel(string fileName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Sheet1");
                var data = GetAnswers();

                for (int i = 0; i < data.Length; i++)
                {
                    sheet.Cells[$"A{i + 1}"].Value = data[i];
                }

                package.Save();
            }
        }
    }
}
