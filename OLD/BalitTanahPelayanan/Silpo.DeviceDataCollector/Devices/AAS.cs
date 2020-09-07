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
    public class AAS : IDeviceFile
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
                        if (!string.IsNullOrEmpty(line.Trim()))
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
                if (rowDatas == null || rowDatas.Count <= 0)
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
                    var worksheet = workbook.Worksheets.Add("Coba Device");
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
                        if (Rows < 6)
                        {
                            if (line.Contains(':') && line.ToCharArray().Where(x=>x == ':').Count()==1)
                            {
                                worksheet.Cells[Rows, 0].Value = line.Split(':')[0].Trim();
                                worksheet.Cells[Rows, 0].Style = style;
                                worksheet.Cells[Rows, 1].Value = line.Split(':')[1].Trim();
                            }
                            else
                            if (line.Length > 15)
                            {
                                worksheet.Cells[Rows, 0].Value = line.Substring(0,15).Trim();
                                worksheet.Cells[Rows, 0].Style = style;
                                worksheet.Cells[Rows, 1].Value = line.Substring(15).Trim();
                            }
                            else
                            {
                                worksheet.Cells[Rows, 0].Value = line;
                            }
                        }else if(Rows>=6 && Rows < 13)
                        {
                            worksheet.Cells[Rows, 0].Value = line.Substring(0, 50).Trim();
                            worksheet.Cells[Rows, 1].Value = line.Substring(50, 21).Trim();
                            worksheet.Cells[Rows, 2].Value = line.Substring(71, 7).Trim();
                            worksheet.Cells[Rows, 3].Value = line.Substring(78, 8).Trim();
                            worksheet.Cells[Rows, 4].Value = line.Substring(86).Trim();
                        }
                        else if (Rows >= 13 && Rows < 18)
                        {
                            worksheet.Cells[Rows, 0].Value = line.Split('=')[0].Trim();
                            worksheet.Cells[Rows, 0].Style = style;
                            worksheet.Cells[Rows, 1].Value = line.Split('=')[1].Trim();
                        }
                        else if (Rows >= 18)
                        {
                            worksheet.Cells[Rows, 0].Value = line.Substring(0, 50).Trim();
                            worksheet.Cells[Rows, 1].Value = line.Substring(50, 21).Trim();
                            worksheet.Cells[Rows, 2].Value = line.Substring(71, 7).Trim();
                            worksheet.Cells[Rows, 3].Value = line.Substring(78, 8).Trim();
                            worksheet.Cells[Rows, 4].Value = line.Substring(86).Trim();
                        }

                       
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
