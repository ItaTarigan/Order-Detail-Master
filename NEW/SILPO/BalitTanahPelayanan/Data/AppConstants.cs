using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Data
{
    public class AppConstants
    {
        public const string DefaultUploadStatus = "Silakan pilih input file csv untuk melakukan import data";

        public const int MaxFileSize = 5 * 1024 * 1024; // 5MB
        public static string DbConnection { get; set; }
        public static string WebRootPath { get; set; }
        public static string GMapApiKey { set; get; }
        public static string UploadFolderPath { set; get; }
        public static string BlobStorageConnection { set; get; }
        public static string DefaultBlobCountainer { set; get; }
        public static string CryptoKey { set; get; }
        public const string NameKey = "username";
      

        

    }

    public class ErrorMessages
    {
        public const string LoginFail = "Login failed, username or password is incorrect.";
    }
}
