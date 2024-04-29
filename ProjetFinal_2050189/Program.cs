using Microsoft.EntityFrameworkCore;
using ProjetFinal_2050189.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProjetFinal2050189Context>(
    options => { options.UseSqlServer(builder.Configuration.GetConnectionString("BDProjetFinal2050189"));
        options.UseLazyLoadingProxies();
    });

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Produits}/{action=Index}/{id?}"
    );
});

app.MapRazorPages();

app.Run();
