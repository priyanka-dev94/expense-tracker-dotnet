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

        public async Task<Expense?> UpdateExpenseAsync(int id, Expense updatedExpense)
        {
            var existingExpense = await _context.Expenses.FindAsync(id);
            if (existingExpense == null)
                return null;

            existingExpense.Description = updatedExpense.Description;
            existingExpense.Amount = updatedExpense.Amount;
            existingExpense.Date = updatedExpense.Date;
            existingExpense.Category = updatedExpense.Category;
            existingExpense.ExpenseType = updatedExpense.ExpenseType;

            await _context.SaveChangesAsync();
            return existingExpense;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
