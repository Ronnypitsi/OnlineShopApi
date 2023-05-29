using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using OnlineShopApi.Data;
using OnlineShopApi.Data.Entities;
using OnlineShopApi.Interfaces;
using OnlineShopApi.Repositories;
using OnlineShopApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ChatConnectionstring")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IHandlerService, HandlerService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", build =>
{
	build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<OrderContext>();
	dbContext.Database.Migrate();
}
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	
}

app.UseHttpsRedirection();
app.UseCors("corsapp");


app.MapControllers();

app.Run();