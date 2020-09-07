using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

using BalitTanahPelayanan.Controllers;

namespace BalitTanahPelayanan.SignalR
{
    [HubName("BoardTugasHub")]
    public class BoardTugasHub : Hub
    {
        [HubMethodName("RequestData")]
        public void RequestData(string _user)
        {
            BoardTugasController ctr = new BoardTugasController();
            var datas = ctr.RequestData(_user);
            Clients.Caller.populateDataTugas(datas);
        }
    }
}