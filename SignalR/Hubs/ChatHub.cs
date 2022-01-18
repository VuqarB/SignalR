using Microsoft.AspNetCore.SignalR;
using SignalR.DAL;
using SignalR.Models;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class ChatHub:Hub
    {
        private AppDbContext _context { get; }
        public ChatHub(AppDbContext context)
        {
            _context = context;
        }
        public Task SendMessageToGroup(string groupname, string message)
        {
            return Clients.Group(groupname).SendAsync("SendMessage", message);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }
    }
}
