using GalejSnack.Client.Pages;
using GalejSnack.Components;
using GalejSnack.DataAccess.Services;
using GalejSnack.DataAccess.Services.Interfaces;
using GalejSnack.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Registrera Alla Controllers
builder.Services.AddControllers();

// Registrera ChatRepository som en Singleton, Singleton innebär att vi alltid får samma instans av ChatRepository
builder.Services.AddSingleton<IChatRepository, ChatRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Mappa endpoints i alla controllers
app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

//Exempel som är samma funktionalitet som /api/chat/all i ChatController 
app.MapGet("all", async (IChatRepository repository) =>
{
    return await repository.GetAllAsync();
});

// Mappa Hubben som en endpoint
app.MapHub<ChatHub>("/hubs/chatHub");

app.Run();
