using GemBox.Spreadsheet;
using Microsoft.Data.Analysis;
using Silpo.DeviceDataCollector.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Silpo.DeviceDataCollector.Devices
{
    public class XDR : IDeviceFile
    {
        public string FileExtension { get => ".xlsx"; }
        private DataTable exportedData { get; set; }
        private DataFrame currentFrame { get; set; }
        public async Task<DataFrame> GetResult()
        {
            if (currentFrame != null)
            {
                return currentFrame;
            }
            else
            {
                throw new Exception("Please open file first.");
            }
        }

        public Task<bool> OpenFile(string FileName)
        {
            try
            {
                //rename duplicate column names
                var lines = File.ReadLines(FileName).ToList();
                var header = lines[0];
                Dictionary<string, int> headerCount = new Dictionary<string, int>();
                string newHeader=string.Empty;
                var ColCount = 0;
                foreach(var item in header.Split(','))
                {
                    var newName = item;
                    if (headerCount.ContainsKey(item))
                    {
                        headerCount[item]++;
                        newName += headerCount[item].ToString();
                    }
                    else
                    {
                        headerCount.Add(item, 0);
                    }
                    if (ColCount > 0)
                        newHeader += ",";
                    newHeader += newName;
                    ColCount++;

                }
                lines[0] = newHeader;
                byte[] byteArray = Encoding.ASCII.GetBytes(string.Join(Environment.NewLine, lines));
                MemoryStream stream = new MemoryStream(byteArray);
                //open as data frame
                currentFrame = DataFrame.LoadCsv(stream, header: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - Reading CSV : {ex.Message}");
                throw new Exception($"Error - Reading CSV : {ex.Message}");
                //return Task.FromResult(false);
            }
         
            return Task.FromResult(true);
        }

        public Task<bool> Run()
        {
            try
            {
                if (currentFrame == null)
                {
                    throw new Exception("Please open file first..");
                }
                else
                {
                    DataTable dt = new DataTable("data");
                    var df = currentFrame;
                    foreach (var dc in df.Columns)
                    {
                        dt.Columns.Add(dc.Name.Replace(" ", "").Trim());
                    }
                    dt.AcceptChanges();
                    for (long i = 0; i < df.Rows.Count; i++)
                    {
                        DataFrameRow row = df.Rows[i];
                        var newRow = dt.NewRow();
                        var cols = 0;
                        foreach (var cell in row)
                        {
                            newRow[cols] = cell.ToString();
                            cols++;
                        }
                        dt.Rows.Add(newRow);
                    }
                    dt.AcceptChanges();
                    exportedData = dt;
                    return Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - Convert to DataTable : {ex.Message}");
                throw new Exception($"Error - Convert to DataTable : {ex.Message}");
                //return Task.FromResult(false);
            }
            
        }

        public Task<bool> SaveToFile(string Filename)
        {
            bool Res = false;
            if (string.IsNullOrEmpty(Filename))
            {
                throw new Exception("Error save file - please specify filename");
            }
            else if (Path.GetExtension(Filename) != ".xlsx")
            {
                throw new Exception("Error save file - Only support excel file (xlsx)");
            }
            else if (exportedData == null)
            {
                throw new Exception("Error save file - Please call Run() first");
            }
            else
            {
                try
                {
                    // If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense(ConfigurationManager.AppSettings["GemboxExcel"]);

                    var workbook = new ExcelFile();
                    var worksheet = workbook.Worksheets.Add("Data XDR");
                    var style = new CellStyle();
                    style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    style.Font.Weight = ExcelFont.BoldWeight;
                    style.FillPattern.SetSolid(System.Drawing.Color.LightGreen);
                    int Cols = 0;
                    foreach (DataColumn dc in exportedData.Columns)
                    {
                        worksheet.Cells[0, Cols].Value = dc.ColumnName;
                        worksheet.Cells[0, Cols].Style = style;
                        Cols++;
                    }
                    var Rows = 0;
                    foreach (DataRow dr in exportedData.Rows)
                    {
                        Rows++;
                        for (int ColIdx = 0; ColIdx < exportedData.Columns.Count; ColIdx++)
                        {
                            worksheet.Cells[Rows, ColIdx].Value = dr[ColIdx].ToString();
                        }
                    }

                    workbook.Save(Filename);
                    Res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error - save to file : {ex.Message}");
                    throw new Exception($"Error - save to file : {ex.Message}");
                }
            }
            return Task.FromResult(Res);
        }
    }
}
