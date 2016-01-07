using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;
using MobileWebApp.Models.PushNotifications;
using System.Threading.Tasks;

namespace MobileWebApp
{
    public class EchoHub : Hub
    {
        //public void StartTimer()
        //{
        //    while (true)
        //    {
        //        Clients.All.showTime(DateTime.Now.ToLongTimeString());
        //        //Thread.Sleep(TimeSpan.FromMinutes(1));
        //        Thread.Sleep(new TimeSpan(0, 0, 45));
        //    }
        //}

        //private readonly SignalRTime _srTime;

        //public EchoHub() : this(SignalRTime.Instance) { }

        //public EchoHub(SignalRTime srTime)
        //{
        //    _srTime = srTime;
        //}

        //public string StartTimer()
        //{
        //    //return _srTime.CurrentTime;
        //    return "testing time";
        //}

        private readonly GroupDispatcher _group;

        public EchoHub() : this(GroupDispatcher.Instance) { }

        public EchoHub(GroupDispatcher group)
        {
            _group = group;
        }


        public void JoinGroup(string userName, string groupName)
        {
            var user = new User()
            {
                userName = userName,
                groupName = groupName,
                connectionId = Context.ConnectionId
            };
            if (_group.AddUserToGroup(user))
            {
                Groups.Add(Context.ConnectionId, groupName);
            }             
        }

        public void LeaveGroup(string userName, string groupName)
        {
            var user = new User()
            {
                userName = userName,
                groupName = groupName,
                connectionId = Context.ConnectionId
            };
            if (_group.RemoveUserFromGroup(user))
            {
                Groups.Remove(Context.ConnectionId, groupName);
            }           
        }

    }
}