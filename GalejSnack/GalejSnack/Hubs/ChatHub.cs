using GalejSnack.DataAccess.Models;
using GalejSnack.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace GalejSnack.Hubs
{
    public class ChatHub(IChatRepository chatRepository) : Hub
    {
        public async Task SendMessage(ChatMessage message)
        {
            await chatRepository.AddAsync(message);
            await Clients.All.SendAsync("SendMessage",message);
        }
    }
}
