// See https://aka.ms/new-console-template for more information

using GalejSnack.DataAccess.Models;
using GalejSnack.DataAccess.Services;

Console.WriteLine("Hello, World!");

var repo = new ChatRepository();

var message = new ChatMessage
{
    Sender = "Galej",
    Message = "Hello, World!",
    Timestamp = DateTime.Now
};

await repo.AddAsync(message);