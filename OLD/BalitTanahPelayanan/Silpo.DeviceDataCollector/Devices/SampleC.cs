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
    public class SampleC : IDeviceFile
    {
        public string FileExtension { get => ".xlsx"; }
        List<string> rowDatas;
        public async Task<DataFrame> GetResult()
        {
           
                throw new Exception("not implemented.");
            
           
        }

        public Task<bool> OpenFile(string FileName)
        {
            try
            {
                if (File.Exists(FileName))
                {
                    var lines = File.ReadAllLines(FileName);
                    rowDatas = new List<string>();
                    foreach (var line in lines)
                    {
                        if(!string.IsNullOrEmpty(line.Trim()))
                            rowDatas.Add(line.Trim());
                    }
                }
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
                if (rowDatas == null || rowDatas.Count<=0)
                {
                    throw new Exception("Please open file first..");
                }
                else
                {
                    /*
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
                    return Task.FromResult(true);*/
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
            else if (rowDatas == null)
            {
                throw new Exception("Error save file - Please open file first");
            }
            else
            {
                try
                {
                    var LastHeader = "";
                    bool isTable = false;
                    // If using Professional version, put your serial key below.
                    SpreadsheetInfo.SetLicense(ConfigurationManager.AppSettings["GemboxExcel"]);

                    var workbook = new ExcelFile();
                    var worksheet = workbook.Worksheets.Add("Data Sample C");
                    var style = new CellStyle();
                    style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    style.Font.Weight = ExcelFont.BoldWeight;
                    style.FillPattern.SetSolid(System.Drawing.Color.LightGreen);

                    var styleHeader = new CellStyle();
                    styleHeader.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    styleHeader.VerticalAlignment = VerticalAlignmentStyle.Center;
                    styleHeader.Font.Weight = ExcelFont.BoldWeight;
                    styleHeader.FillPattern.SetSolid(System.Drawing.Color.AliceBlue);
                    int Rows = 0;
                    foreach (var line in rowDatas)
                    {
                        switch (line)
                        {
                            case string x when x.Contains("Report:"):
                                worksheet.Cells[Rows,0 ].Value = x.Split(':')[0];
                                worksheet.Cells[Rows,0 ].Style = style;
                                worksheet.Cells[Rows,1].Value = x.Split(':')[1];
                                break;
                            case string x when x.Contains(":"):
                                worksheet.Cells[Rows,0 ].Value = x.Split(':')[0];
                                worksheet.Cells[Rows,0 ].Style = style;
                                worksheet.Cells[Rows,1 ].Value = x.Split(':')[1];
                                break;
                            case string x when x.Contains("\t") && isTable:
                                if (x.Contains("*"))
                                {
                                    x = x.Replace("*","").Trim();
                                }
                                var fields = x.Split('\t');
                                var ColX = 0;
                                foreach(var item in fields)
                                {
                                    //worksheet.Cells[0, Cols].Style = style;
                                    worksheet.Cells[Rows,ColX++].Value = item;
                                }
                                break;
                            default:
                                if(line.Contains("STD Data") || line.Contains("Sample"))
                                {
                                    isTable = true;
                                }
                                else
                                {
                                    isTable = false;
                                }
                                LastHeader = line.Trim();
                                worksheet.Cells[Rows,0].Value = line;
                                worksheet.Cells[Rows,0].Style = styleHeader;
                                break;
                        }

                        //worksheet.Cells[0, Cols].Value = dc.ColumnName;
                        //worksheet.Cells[0, Cols].Style = style;
                        Rows++;
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
