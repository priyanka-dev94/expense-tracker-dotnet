using ExpenseTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Add controller support
builder.Services.AddControllers(); // ✅ Needed for [ApiController] controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Your DbContext
builder.Services.AddDbContext<ExpenseTrackerDbContext>(options =>
    options.UseInMemoryDatabase("ExpenseDb"));

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
