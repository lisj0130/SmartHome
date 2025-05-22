using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace ChatAppBackend.Hubs
{
    public class SmartHomeHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Användare ansluten: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (exception != null)
            {
                Console.WriteLine($"Ett error uppstod när du försökte frånkoppla: {exception.Message}");
            }
            else
            {
                Console.WriteLine($"Användare frånkopplad: {Context.ConnectionId}");
            }

            return base.OnDisconnectedAsync(exception);
        }

        public async Task TurnOnLight(int id)
        {
            await Clients.All.SendAsync("TurnOnLight", id, 1);
        }

        public async Task TurnOffLight(int id)
        {
            await Clients.All.SendAsync("TurnOffLight", id, 0);
        }

        //Lägg till eftersom
    }
}