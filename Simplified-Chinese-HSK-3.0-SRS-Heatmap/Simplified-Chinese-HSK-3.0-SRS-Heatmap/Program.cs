using Microsoft.EntityFrameworkCore;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Data;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Helpers;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.infrastructure;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Services;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

//Get database connection.
builder.Services.AddDbContext<AnkiDbContext>(options =>
   options.UseSqlite(DbConnectionHelper.GetDatabaseConnectionString()));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IAnki, AnkiRepo>();
builder.Services.AddTransient<IHsk, HskRepo>();
builder.Services.AddMvc();

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