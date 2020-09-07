using Silpo.DeviceDataCollector.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Silpo.DeviceDataCollector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Setup();
            

        }


        void Setup()
        {
            CmbAlat.Items.Clear();
            foreach(var item in AppConstants.DeviceData)
            {
                CmbAlat.Items.Add(item.Key);
            }
            CmbAlat.SelectedIndex = 0;
            SetTempFilename();
            BtnSelect.Click += (a, b) => {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        //string[] files = Directory.GetFiles(fbd.SelectedPath);
                        SetTempFilename(fbd.SelectedPath);
                        //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                    }
                }
            };
            BtnOpenFile.Click += (a, b) => {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Title = "Browse File Alat",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "csv",
                    Filter = "Csv files (*.csv)|*.csv|Text files (*.txt)|*.txt|Tsv files (*.tsv)|*.tsv|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TxtOpenFile.Text = openFileDialog1.FileName;
                }
            };
            BtnSave.Click += (a, b) => {
                if (CmbAlat.SelectedIndex > -1)
                {
                    var obj = AppConstants.DeviceData[CmbAlat.Text];
                    try
                    {
                        if (obj.OpenFile(TxtOpenFile.Text).Result)
                            if (obj.Run().Result)
                                if (obj.SaveToFile(TxtFile.Text).Result)
                                {
                                    TxtStatus.Text = "File berhasil di export";
                                if(ChkOpen.IsChecked==true)
                                    {
                                        FileInfo info = new FileInfo(TxtFile.Text);
                                        if (info.Exists)
                                        {
                                            System.Diagnostics.Process.Start(info.FullName);
                                        }
                                    }
                                }
                    }catch(Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message, "Terjadi Kesalahan");
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Silakan pilih Alat terlebih dahulu.","Perhatian");
                }

            };
        }

        void SetTempFilename(string TargetFolder="")
        {
            //if (string.IsNullOrEmpty(TxtFile.Text))
            {
                if (CmbAlat.SelectedIndex > -1)
                {
                    var obj = AppConstants.DeviceData[CmbAlat.Text];
                    if (string.IsNullOrEmpty(TargetFolder))
                    {
                        TargetFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    }
                    
                    TxtFile.Text = $"{TargetFolder}\\DataAlat_{DateTime.Now.ToString("dd_MMM_yyyy_HH_mm")}{obj.FileExtension}";
                }
                
            }
                
        }
    }
}
