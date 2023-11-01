using BE_FacilityFeedBackWebApi.Configuration;
using BE_FacilityFeedBackWebApi.Middlewares;
using Domain.Entity;

var builder = WebApplication.CreateBuilder(args);


// IConfiguration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddDbContext<FacilityReportContext>();

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
// USING MIDDLEWARE
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
