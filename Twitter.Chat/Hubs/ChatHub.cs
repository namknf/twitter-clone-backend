namespace Twitter.Chat.Hubs
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;

    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
