using BlackJackServer.Hubs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
builder.Services.AddSignalR();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<GameHub>("/gameHub");

app.Run();
