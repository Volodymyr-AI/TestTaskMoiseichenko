using Microsoft.AspNetCore.SignalR;

namespace Test_task.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user,message);
        }
    }
}
