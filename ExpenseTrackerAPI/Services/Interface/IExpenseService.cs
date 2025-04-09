using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Services.Interface
{
    public interface IExpenseService
    {
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task<List<Expense>> GetAllExpensesAsync();
    }
}
