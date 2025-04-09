using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost("addexpense")]
        public async Task<IActionResult> AddExpense([FromBody] Expense expense)
        {
            var result = await _expenseService.AddExpenseAsync(expense);
            return CreatedAtAction(nameof(GetExpenseById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseService.GetExpenseByIdAsync(id);
            if (expense == null) return NotFound();
            return Ok(expense);
        }

        [HttpGet("getexpenses")]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return Ok(expenses);
        }
    }
}
