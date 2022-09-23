using FantasyBets;
using FantasyBets.Data;
using FantasyBets.Logic.Parsers;
using FantasyBets.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextFactory<DataContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(DataContext.FantasyDb)}.db"));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
})
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddLogging(options => options.AddConsole());

builder.Services.AddHostedService<UpdateRoundsHostedService>();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IDataProvider, DataProvider>();
builder.Services.AddSingleton<RoundParser>();
builder.Services.AddSingleton(builder.Configuration.Get<Configuration>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
