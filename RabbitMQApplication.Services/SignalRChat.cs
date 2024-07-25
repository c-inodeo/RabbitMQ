using Microsoft.AspNetCore.SignalR;


namespace RabbitMQApplication.Services
{
    public class SignalRChat : Hub
    {
        public async Task SendMessageSignalR(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
