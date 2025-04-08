using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Data;


namespace ExpenseTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseTrackerDbContext _context;

        public ExpenseController(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            var expenses = _context.Expenses.ToList();
            return Ok(expenses);
        }

        [HttpPost]
        public IActionResult CreateExpense([FromBody] Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return Ok(expense);
        }
    }

}
