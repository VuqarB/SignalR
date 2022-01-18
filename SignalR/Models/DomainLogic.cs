using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Domainlogic
{
    public class MessagePayload
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }

    [Authorize]
    public class MessageHub : Hub
    {
        // connected IDs
        private static readonly HashSet<string> ConnectedIds = new HashSet<string>();

        public override async Task OnConnectedAsync()
        {
            ConnectedIds.Add(Context.ConnectionId);

            await Clients.All.SendAsync("SendAction", "joined", ConnectedIds.Count);
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            ConnectedIds.Remove(Context.ConnectionId);

            await Clients.All.SendAsync("SendAction", "left", ConnectedIds.Count);
        }

        public async Task Send(MessagePayload message)
        {
            await Clients.All.SendAsync("SendMessage", message);
        }
    }
}