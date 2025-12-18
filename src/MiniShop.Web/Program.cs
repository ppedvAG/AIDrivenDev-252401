using MiniShop.Application;
using MiniShop.Application.Ai;
using MiniShop.Infrastructure.Ai;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Use Cases
builder.Services.AddTransient<AddItemToCart>();

// Register AI Client
// Note: In a real app, you might want to configure this via appsettings.json
var openAiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
if (!string.IsNullOrEmpty(openAiKey))
{
    builder.Services.AddSingleton<ILlmClient>(sp => new OpenAiResponsesClient(openAiKey));
}
else
{
    // Fallback or throw, for now we'll register the local one or a dummy if needed
    // Assuming LocalLlmClient needs an HttpClient
    builder.Services.AddHttpClient<ILlmClient, LocalLlmClient>(client => 
    {
        client.BaseAddress = new Uri("http://localhost:11434"); // Default Ollama port
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
