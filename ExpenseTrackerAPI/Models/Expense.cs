namespace ExpenseTrackerAPI.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string? Description { get; set; }         // e.g., "Grocery shopping"
        public decimal Amount { get; set; }              // e.g., 1200.50
        public DateTime Date { get; set; }               // e.g., 2025-04-06
        public string? Category { get; set; }            // e.g., "Food", "Travel"
        public string? ExpenseType { get; set; }        // e.g., "Debit", "Credit"
    }
}
