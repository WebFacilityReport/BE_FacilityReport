using Infrastructure.IService.ServiceImplement;
using WebRazorPage.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
.SetBasePath(builder.Environment.ContentRootPath)
.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
.Build();
builder.Services.AddRazorPages();
builder.Services.DependencyInjection(configuration);
builder.Services.AddSingleton(builder.Services.DependencyInjection(configuration));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRouting(); // Add this line before UseEndpoints

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapHub<ChatHub>("/chatHub"); // Map the ChatHub to a specific endpoint
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
