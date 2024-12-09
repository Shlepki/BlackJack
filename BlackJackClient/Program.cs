using BlackJackClient;
using BlackJackClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddSingleton(sp => new GameClient("http://localhost:5001/gamehub"));

await builder.Build().RunAsync();
