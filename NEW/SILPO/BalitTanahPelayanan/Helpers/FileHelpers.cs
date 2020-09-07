using BalitTanahPelayanan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalitTanahPelayanan.Helpers
{
    public class FileHelpers
    {
        public static string GetAbsolutePath(string relativePath)

        {
            /*
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;*/
            var file = System.IO.Path.Combine(AppConstants.WebRootPath, relativePath);
            return file;

        }
    }
}
