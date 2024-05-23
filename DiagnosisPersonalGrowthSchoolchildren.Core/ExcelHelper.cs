using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using System.Drawing;

namespace DiagnosisPersonalGrowthSchoolchildren.Core
{
    public class ExcelHelper
    {
        public ExcelHelper()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public Dictionary<string, Dictionary<char, int[]>> CalculateResult(string fileName)
        {
            var file = new FileInfo(fileName);
            var result = new Dictionary<string, Dictionary<char, int[]>>();

            using (var package = new ExcelPackage(file))
            {
                foreach (var sheet in package.Workbook.Worksheets)
                {
                    var column = 'A';
                    var numberOfAnswers = Scales.GetValues().Length;
                    var resultsByColumns = new Dictionary<char, int[]>();
                    while (sheet.Cells[$"{column}1"].Value is not null)
                    {
                        var isNumeric = int.TryParse(sheet.Cells[$"{column}1"].Value.ToString(), out _);
                        var startCell = isNumeric ? 1 : 2;
                        var range = $"{column}{startCell}:{column}{numberOfAnswers + startCell - 1}";
                        var cells = (object[,])sheet.Cells[range].Value;
                        var data = new int[numberOfAnswers];
                        for (int i = 0; i < numberOfAnswers; i++) data[i] = Convert.ToInt32(cells[i, 0]);
                        var sums = new HandlerOfResults().CalculateResult(data);
                        resultsByColumns.Add(column, sums);
                        column++;
                    }
                    result.Add(sheet.Name, resultsByColumns);

                }
            }

            return result;
        }

        public void DrawCharts(string fileName, Dictionary<string, Dictionary<char, int[]>> data)
        {
            foreach(var sheet in data)
            {
                foreach (var column in sheet.Value)
                {
                    var sheetName = $"{sheet.Key}_{column.Key}";
                    DrawChart(fileName, sheetName, column.Value);
                }
            }
        }

        private void DrawChart(string fileName, string sheetName, int[] data)
        {
            var file = new FileInfo(fileName);

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add(sheetName);

                FillCells(sheet, data);

                var chart = sheet.Drawings.AddChart($"Chart_{sheetName}", eChartType.ColumnClustered);
                chart.SetSize(800, 300);
                chart.SetPosition(20, 400);
                chart.Title.Text = $"Диагностика личностного роста школьника";
                chart.Title.Font.Size = 16;
                chart.Title.Font.Bold = true;
                chart.Title.Font.Fill.Color = Color.DarkGreen;
                chart.Series.Add($"B1:B{data.Length}", $"A1:A{data.Length}");

                package.Save();
            }
        }

        private void FillCells(ExcelWorksheet sheet, int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                sheet.Cells[$"A{i + 1}"].Value = $"Шкала {i + 1}";
                sheet.Cells[$"B{i + 1}"].Value = data[i];
                sheet.Cells[$"C{i + 1}"].Value = GetResultTextByScale(data[i]);
            }
        }

        private string GetResultTextByScale(int result)
        {
            if (result >= 15 && result <= 28)
            {
                return "устойчиво-позитивное отношение";
            }

            if (result >= 1 && result <= 14)
            {
                return "ситуативно-позитивное отношение";
            }

            if (result >= -14 && result <= -1)
            {
                return "ситуативно-негативное отношение";
            }

            if (result >= -28 && result <= -15)
            {
                return "устойчиво-негативное отношение";
            }

            return "результат неизвестен";
        }
    }
}
