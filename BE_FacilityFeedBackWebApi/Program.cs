using BE_FacilityFeedBackWebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);


// IConfiguration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .Build();


builder.Services
    .DependencyInjection(configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
//app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/healthchecks");
    endpoints.MapControllers();
});

app.Run();
