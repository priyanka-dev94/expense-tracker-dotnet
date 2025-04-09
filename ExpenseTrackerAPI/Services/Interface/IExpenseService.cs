using ExpenseTrackerAPI.Models;

namespace ExpenseTrackerAPI.Services.Interface
{
    public interface IExpenseService
    {
        Task<Expense> AddExpenseAsync(Expense expense);
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task<List<Expense>> GetAllExpensesAsync();
        Task<Expense?> UpdateExpenseAsync(int id, Expense updatedExpense);
        Task<bool> DeleteExpenseAsync(int id);

    }
}
