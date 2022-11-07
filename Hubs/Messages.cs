
using Microsoft.AspNetCore.SignalR;
using TwitterCloneBackend.Hubs;

namespace TwitterCloneBackend.NewFolder
{
    public class MessagesHub: Hub
    {
        public async Task NotifiyNewMessage(NewMessage newMessage)
        {
            await Clients.All.SendAsync("RecieveNewMessage", 
                (newMessage)
            );
        }
    }
}
