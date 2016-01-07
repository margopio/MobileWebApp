using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Concurrent;

namespace MobileWebApp.Models.PushNotifications
{
    public class GroupDispatcher
    {        
        // Singleton instance
        private readonly static Lazy<GroupDispatcher> _instance = new Lazy<GroupDispatcher>(
            () => new GroupDispatcher(GlobalHost.ConnectionManager.GetHubContext<EchoHub>().Clients));

        private readonly ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();
        private readonly Timer _timer1;
        private readonly Timer _timer2;
        private readonly Timer _timer3;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="clients"></param>
        private GroupDispatcher(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
            
            // Fire the timer every second.
            _timer1 = new Timer(UpdateTime1, null, 0, 30000);
            _timer2 = new Timer(UpdateTime2, null, 0, 40000);
            _timer3 = new Timer(UpdateTime3, null, 0, 50000);
           
        } 
        
        /// <summary>
        /// Broadcast to all the current time.
        /// </summary>
        /// <param name="state"></param>
        private void UpdateTime1(object state)
        {
            Clients.All.broadcastTime(CurrentTime1);
        }

        private void UpdateTime2(object state)
        {
            Clients.Group("1001").broadcastTime(CurrentTime2);
        }

        private void UpdateTime3(object state)
        {
            Clients.Group("1002").broadcastTime(CurrentTime3);
        } 

        /// <summary>
        /// Singleton instance of the GroupDispatcher class.
        /// </summary>
        public static GroupDispatcher Instance
        {
            get
            {
                return _instance.Value;
            }
        } 

        /// <summary>
        /// Clients from the Hub which will be used to broadcast time updates.
        /// </summary>
        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        /// <summary>
        /// Current time formatted as a string.
        /// </summary>
        public string CurrentTime1
        {
            get
            {
                return string.Format("To all groups, the server time is {0}", DateTime.Now.ToLongTimeString());
            }
        }

        public string CurrentTime2
        {
            get
            {
                return string.Format("To Group 1001, the server time is {0}", DateTime.Now.ToLongTimeString());
            }
        }

        public string CurrentTime3
        {
            get
            {
                return string.Format("To Group 1002, the server time is {0}", DateTime.Now.ToLongTimeString());
            }
        }

        public bool AddUserToGroup(User user)
        {
            string userName = user.userName;
            return _users.TryAdd(userName, user);
        }

        public bool RemoveUserFromGroup(User user)
        {
            string userName = user.userName;
            User value1;
            return _users.TryRemove(userName, out value1);
        }

    }
}