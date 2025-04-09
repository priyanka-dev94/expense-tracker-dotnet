using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.Models;
using ExpenseTrackerAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Services.Implementation
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseTrackerDbContext _context;

        public ExpenseService(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }
    }
}
