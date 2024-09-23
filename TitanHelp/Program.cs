using Microsoft.EntityFrameworkCore;
using TitanHelp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Should we use stub or real database? read from appsettings.json
var useStubDb = builder.Configuration.GetValue<bool>("UseStubDb");
SetupDb(useStubDb);

var app = builder.Build();

if (!useStubDb)
{
    // Apply pending entity framework migrations at startup for convenience
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<TicketDb>();
    dbContext.Database.Migrate(); // This will apply any pending migrations
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
return;

void SetupDb(bool useStub)
{
    if (useStub)
    {
        // Inject our stub database
        builder.Services.AddSingleton<ITicketDb, StubTicketDb>();
    }
    else
    {
        // Set up actual sqllite database context
        builder.Services.AddDbContext<TicketDb>(options =>
        {
            // This will create a database file in the your local app data folder if it does not exist
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = System.IO.Path.Join(Environment.GetFolderPath(folder), "titan_help.db");
            Console.WriteLine($"Using database at {path}");
            options.UseSqlite($"Data Source={path}");
        });
    
        // Register ITicketDb as a scoped service, resolving to TicketDb
        builder.Services.AddScoped<ITicketDb, TicketDb>();
    }
}