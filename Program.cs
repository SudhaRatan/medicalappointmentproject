using medicalappointmentproject.DataAccess;
using medicalappointmentproject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<MedicalprojectContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDoctorDetailsService,DoctorDetailsService>();
builder.Services.AddScoped<IDiseasesDoctorDetailsService, DiseasesDoctorDetailsService>();
builder.Services.AddScoped<IAppointmentsService, AppointmentsService>();

var app = builder.Build();

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
    pattern: "{controller=Appointments}/{action=Index}/{id?}");

app.Run();
