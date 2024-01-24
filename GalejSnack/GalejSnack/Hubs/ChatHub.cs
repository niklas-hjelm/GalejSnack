using GalejSnack.DataAccess.Models;
using GalejSnack.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace GalejSnack.Hubs
{
    // Hub är en klass som ärver från SignalR Hub, den används för att skicka meddelanden till klienter
    // Här används en primary constructor för att injecta ChatRepository, Primary constructor är en nyhet i C# 12 (.NET 8)
    public class ChatHub(IChatRepository chatRepository) : Hub
    {
        public async Task SendMessage(ChatMessage message)
        {
            await chatRepository.AddAsync(message);
            await Clients.All.SendAsync("SendMessage",message);
        }
    }
}
