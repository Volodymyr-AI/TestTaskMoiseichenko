using ChatDAL.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Test_task.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(User user, Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user,message);
        }
    }
}
