using Silpo.DeviceDataCollector.Devices;
using Silpo.DeviceDataCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Silpo.DeviceDataCollector.Helpers
{
    public class AppConstants
    {
        public static readonly Dictionary<string, IDeviceFile> DeviceData = new Dictionary<string, IDeviceFile>() {
            { "Mineralogi - XDR" , new XDR() },
              { "Kimia - Spectro (Sample C)" , new SampleC() },
              { "Kimia - AAS" , new AAS() },
            {"Fisika - Quantachrome Multipoint BET",new Quantachrome_MultipointBET() },
            { "Fisika - Quantachrome Total Pore Vol. ", new Quantachrome_TotalPoreVolume()},
               { "Fisika - Quantachrome Average Pore Size", new Quantachrome_AveragePoreSize()}
        };
    }
}
