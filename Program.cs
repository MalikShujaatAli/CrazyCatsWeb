using CrazyCatsWeb.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CrazyCatsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrazyCatsContext")));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CrazyCatsContext>();

    // Ensure the database is created
    context.Database.EnsureCreated();

    // Seed Animals data
    if (!context.Animals.Any())
    {
        context.Animals.AddRange(
            new Animal
            {
                Name = "Max",
                Species = "Dog",
                Breed = "Labrador",
                Description = "Friendly and energetic.",
                IsAdopted = false
            },
            new Animal
            {
                Name = "Whiskers",
                Species = "Cat",
                Breed = "Siamese",
                Description = "Quiet and affectionate.",
                IsAdopted = true
            },
            new Animal
            {
                Name = "Leo",
                Species = "Lion",
                Breed = "African Lion",
                Description = "A rescued lion, now safe and healthy.",
                IsAdopted = false
            }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
