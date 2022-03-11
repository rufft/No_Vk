using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace No_Vk.Domain.Models.SignalRHubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

        public const string Url = "/signalrchat";

        public async Task Broadcast()
        {
            await Clients.All.SendAsync("Broadcast");
        }

        public override async Task OnConnectedAsync()
        {
            _logger.LogInformation(1, $"{Context.ConnectionId} connected");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception e)
        {
            _logger.LogInformation(1, $"Disconnected { e?.Message } { Context.ConnectionId }");
            await base.OnDisconnectedAsync(e);
        }
    }
}
