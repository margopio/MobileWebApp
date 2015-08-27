using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;

namespace MobileWebApp
{
    public class EchoHub : Hub
    {
        public void StartTimer()
        {
            while (true)
            {
                Clients.All.showTime(DateTime.Now.ToLongTimeString());
                Thread.Sleep(TimeSpan.FromSeconds(30));
            }
        }
    }
}