using GalejSnack.DataAccess.Models;
using GalejSnack.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalejSnack.Controllers
{

    // Controller är en klass som ärver från ControllerBase, den används för att gruppera endpoints
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(IChatRepository chatRepository) : ControllerBase
    {
        // Exempel på en endpoint som returnerar alla ChatMessages på /api/chat/all
        [HttpGet("all")]
        public async Task<IEnumerable<ChatMessage>> GetAllMessages()
        {
            return await chatRepository.GetAllAsync();
        }

        // Exempel på en endpoint som tar emot en ChatMessage och lägger till den i databasen med pathen /api/chat
        [HttpPost]
        public async Task PostMessage(ChatMessage newMessage)
        {
            await chatRepository.AddAsync(newMessage);
        }
    }
}
