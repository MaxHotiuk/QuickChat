using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace QuickChat.Client.Services
{
    public class ChatService
    {
        private HubConnection? _hubConnection;

        public event Action<string, string>? MessageReceived;

        public async Task StartAsync()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("//https://mango-flower-07cf40d10.5.azurestaticapps.net/chathub")
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                MessageReceived?.Invoke(user, message);
            });

            await _hubConnection.StartAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            if (_hubConnection != null)
            {
                await _hubConnection.SendAsync("SendMessage", user, message);
            }
        }
    }
}

