﻿using OfficeOpenXml;
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
                chart.SetSize(800, 300);
                chart.SetPosition(20, 200);
                chart.Title.Text = "Диагностика личностного роста школьников";
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
            }
        }
    }
}
