using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalitTanahPelayanan.SignalR
{
    [HubName("NotificationHub")]
    public class NotificationHub : Hub
    {
        [HubMethodName("PushNotification")]
        public void PushNotification(string Role, string Message, string UrlLink)
        {
            Clients.All.PushNotification(Role, Message, UrlLink);
        }
    }
}