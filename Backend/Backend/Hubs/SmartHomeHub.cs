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
            Console.WriteLine($"Anv�ndare ansluten: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if (exception != null)
            {
                Console.WriteLine($"Ett error uppstod n�r du f�rs�kte fr�nkoppla: {exception.Message}");
            }
            else
            {
                Console.WriteLine($"Anv�ndare fr�nkopplad: {Context.ConnectionId}");
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

        //L�gg till eftersom
    }
}