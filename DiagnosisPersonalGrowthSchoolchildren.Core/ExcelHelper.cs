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

        public int[] GetDataFromExcel(string fileName, string sheetName) 
        {
            var file = new FileInfo(fileName);
            var result = new int[Scales.GetValues().Length];

            using (var package = new ExcelPackage(file))
            {
                var sheet = package.Workbook.Worksheets[sheetName];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = Convert.ToInt32(sheet.Cells[$"A{i + 1}"].Value);
                }
            }

            return result;
        }

        public void DrawChart(string fileName, string sheetName, int[] data)
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
