using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Services.Implementation;
using ExpenseTrackerAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Add controller support
builder.Services.AddControllers(); // ✅ Needed for [ApiController] controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Your DbContext
builder.Services.AddDbContext<ExpenseTrackerDbContext>(options =>
    options.UseInMemoryDatabase("ExpenseDb"));

builder.Services.AddScoped<IExpenseService, ExpenseService>();

var app = builder.Build();

// 🔧 Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔧 Map controller endpoints
app.MapControllers(); 
app.Run();
