using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;

namespace DiagnosisPersonalGrowthSchoolchildren.Core
{
    public class ExcelChart
    {
        private readonly int[] _data;

        public ExcelChart(int[] data)
        {
            _data = data;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void DrawChart(string fileName)
        {
            var file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Sheet1");
                FillCells(sheet);

                var chart = sheet.Drawings.AddChart("Chart1", eChartType.ColumnClustered);
                chart.SetSize(300, 300);
                chart.SetPosition(50, 150);
                chart.Title.Text = "Диагностика личностного роста школьников";
                chart.Series.Add($"A1:A{_data.Length}");

                package.Save();
            }
        }

        private void FillCells(ExcelWorksheet sheet)
        {
            for (int i = 0; i < _data.Length; i++)
            {
                sheet.Cells[$"A{i + 1}"].Value = _data[i];
            }
        }
    }
}
