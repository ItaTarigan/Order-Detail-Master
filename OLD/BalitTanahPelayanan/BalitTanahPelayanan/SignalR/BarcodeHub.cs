using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalitTanahPelayanan.SignalR
{
    [HubName("BarcodeHub")]
    public class BarcodeHub : Hub
    {
        public void PrintBarcode(string ClientName, List<string> Barcodes)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.PrintBarcode(ClientName, Barcodes);
        }
    }
}