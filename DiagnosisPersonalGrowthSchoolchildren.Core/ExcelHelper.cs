using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

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

        public void DrawChart(string fileName, int[] data)
        {
            var file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Sheet1");
                FillCells(sheet, data);

                var chart = sheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
                chart.SetSize(300, 300);
                chart.SetPosition(50, 150);
                chart.Title.Text = "Диагностика личностного роста школьников";
                chart.Series.Add($"A1:A{data.Length}");

                package.Save();
            }
        }

        private void FillCells(ExcelWorksheet sheet, int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                sheet.Cells[$"A{i + 1}"].Value = data[i];
            }
        }
    }
}
