using GalejSnack.DataAccess.Models;
using GalejSnack.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GalejSnack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController(IChatRepository chatRepository) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IEnumerable<ChatMessage>> GetAllMessages()
        {
            return await chatRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task PostMessage(ChatMessage newMessage)
        {
            await chatRepository.AddAsync(newMessage);
        }
    }
}
