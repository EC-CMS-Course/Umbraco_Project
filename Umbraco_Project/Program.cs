using Azure.Communication.Email;
using Umbraco_Project.Interfaces;
using Umbraco_Project.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .Build();

//Added for email-service
builder.Services.AddSingleton(x => new EmailClient(builder.Configuration["ACS:ConnectionString"]));
builder.Services.AddTransient<IEmailService, EmailService>();
// end added for email-service

builder.Services.AddScoped<IFormSubmissionService, FormSubmissionService>();


WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

//Added for email-service
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
// end added for email-service


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();
