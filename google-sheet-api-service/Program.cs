using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MvcBuildingAnimSettingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcBuildingAnimSettingContext")));

builder.Services.AddDbContext<MvcStoryDialogueContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcStoryDialogueContext")));

builder.Services.AddDbContext<MvcBuildingLevelSizeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcBuildingLevelSizeContext")));

builder.Services.AddDbContext<MvcStoryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcStoryContext")));

builder.Services.AddDbContext<MvcIslandContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcIslandContext")));

builder.Services.AddDbContext<MvcDiaryTitleContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcDiaryTitleContext")));

builder.Services.AddDbContext<MvcDiaryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcDiaryContext")));

builder.Services.AddDbContext<MvcCharacterContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcCharacterContext")));

builder.Services.AddDbContext<MvcBuildingStyleContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcBuildingStyleContext")));

builder.Services.AddDbContext<MvcBuildingLevelContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcBuildingLevelContext")));

builder.Services.AddDbContext<MvcBuildingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcBuildingContext")));

builder.Services.AddDbContext<MvcTestFileContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcTestFileContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
