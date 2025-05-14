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

        //L�gg till eftersom
    }
}

