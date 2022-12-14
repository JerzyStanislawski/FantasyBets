using FantasyBets;
using FantasyBets.Data;
using FantasyBets.Evaluation;
using FantasyBets.Logic.Parsers;
using FantasyBets.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(options => { options.DetailedErrors = true; });

if (builder.Environment.IsDevelopment())
{
    var dbFileName = $"{nameof(DataContext.FantasyDb)}.db";
    builder.Services.AddDbContextFactory<DataContext>(opt =>
        opt.UseSqlite($"Data Source={dbFileName}"));
}
else
{
    builder.Services.AddDbContextFactory<DataContext>(opt =>
        opt.UseSqlServer(builder.Configuration.GetConnectionString("Data")));
}

builder.Services.AddDefaultIdentity<FantasyUser>(options =>
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
builder.Services.AddHostedService<UpdateBetsHostedService>();
builder.Services.AddHostedService<GameStatsHostedService>();

builder.Services.AddHttpClient();
builder.Services.AddHttpClient(nameof(UpdateBetsHostedService));
builder.Services.AddSingleton<IDataProvider, DataProvider>();
builder.Services.AddSingleton<IBetsProvider, BetsProvider>();
builder.Services.AddSingleton<CurrentRoundProvider>();
builder.Services.AddSingleton<RoundParser>();
builder.Services.AddSingleton<RoundBetsParser>();
builder.Services.AddSingleton<GameBetsParser>();
builder.Services.AddSingleton<GameStatsParser>();
builder.Services.AddSingleton<BetsEvaluator>();
builder.Services.AddSingleton(builder.Configuration.Get<Configuration>());
builder.Services.AddSingleton<BettingService>();

builder.Services.AddScoped<LoggedUserService>();
builder.Services.AddScoped<StateContainer>();
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPINSIGHTS_CONNECTIONSTRING"]);

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

GlobalLock.Lock();

app.Run();
