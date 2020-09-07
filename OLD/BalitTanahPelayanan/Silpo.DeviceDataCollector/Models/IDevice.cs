using Microsoft.Data.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silpo.DeviceDataCollector.Models
{
    public interface IDeviceFile
    {
        Task<bool> Run();
        Task<DataFrame> GetResult();
        Task<bool> OpenFile(string FileName);
        Task<bool> SaveToFile(string Filename);

        string FileExtension { get;  }
    }
}
