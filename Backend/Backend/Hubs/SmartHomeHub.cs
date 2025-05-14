using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Runtime.Remoting.Contexts;

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

        //Lägg till eftersom
    }
}

