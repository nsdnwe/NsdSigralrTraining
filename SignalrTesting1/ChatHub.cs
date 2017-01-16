using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalrTesting1 {
    public class ChatHub : Hub {
        private static List<UserConnection> connectionList = new List<UserConnection>();
        public void Hello() {
            Clients.All.hello("Hello all");
        }

        public void Send(string sendFromUserId, string sentFromName, string toUserId, string message) {
            var connections = connectionList.Where(z => z.UserId == toUserId);
            foreach (var item in connections) { // Same user may use the app from more than one device
                Clients.Client(item.ConnectionId).broadcastMessage(sentFromName, message);
            }
        }

        // Must have userId in querystring! 
        // See sample web page how to define in JS
        public override Task OnConnected() {
            connectionList.Add(new UserConnection() {
                UserId = Context.QueryString["userId"],
                ConnectionId = Context.ConnectionId
            });
            return base.OnConnected();
        }
    }
}