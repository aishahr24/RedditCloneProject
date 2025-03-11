using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RedditCloneProject;
using RedditCloneProject.Data; // <- Tilføj dette namespace
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5149/") });
builder.Services.AddScoped<ApiService>(); // Sørg for ApiService er tilføjet her!

await builder.Build().RunAsync();