using BalitTanahPelayanan.SignalR;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BalitTanahPelayanan.Pages.Private.Test
{
    public partial class TestSendNotif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnSend.Click += (a, b) => {
                var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                context.Clients.All.PushNotification("All", TxtMsg.Text , "https://silpo.id");
            };
        }
    }
}