using Microsoft.AspNetCore.SignalR;
using SignalR.HubModels;

namespace SignalR.HubConfig
{
    public partial class MyHub
    {
        public async Task getOnlineUsers()
        {
            Guid currUserId = ctx.Connections.Where(c => c.SignalrId == Context.ConnectionId).Select(c => c.PersonId).SingleOrDefault();
            List<User> onlineUsers = ctx.Connections
                .Where(c => c.PersonId != currUserId)
                .Select(c =>
                    new User(c.PersonId, ctx.Person.Where(p => p.Id == c.PersonId).Select(p => p.Name).SingleOrDefault(), c.SignalrId)
                ).ToList();
            await Clients.Caller.SendAsync("getOnlineUsersResponse", onlineUsers);
        }


        public async Task sendMsg(string connId, string msg)
        {
            await Clients.Client(connId).SendAsync("sendMsgResponse", Context.ConnectionId, msg);
        }
    }
}
