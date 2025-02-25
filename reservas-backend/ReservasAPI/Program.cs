using Microsoft.EntityFrameworkCore;
using ReservasAPI.Data;
using ReservasAPI.Repositories;
using ReservasAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppointmentsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IServiceService, ServiceService>();

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder
        .WithOrigins("http://localhost:5173") // 
        .WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS") // 
        .WithHeaders("*"); // 
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(); // here it is
app.UseRouting(); // here it is

app.UseHttpsRedirection();
app.UseCors("ApiCorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
