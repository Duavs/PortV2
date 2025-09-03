using Microsoft.AspNetCore.SignalR;
using PortV2.Hubs;

namespace PortV2.Services
{
    public class ChatService
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public ChatService(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string user, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}