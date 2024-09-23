using Microsoft.AspNetCore.SignalR;

namespace SignalR.HubConfig
{

        public class MyHub : Hub
        {
            public async Task askServer(string someTextFromClient)
            {
                string tempString;

                if (someTextFromClient == "hey")
                {
                    tempString = "message was 'hey'";
                }
                else
                {
                    tempString = "message was something else";
                }

                await Clients.Client(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);
            }
        }
    
}
