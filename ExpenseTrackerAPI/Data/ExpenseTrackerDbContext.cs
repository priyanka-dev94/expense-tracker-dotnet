namespace ExpenseTrackerAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using ExpenseTrackerAPI.Models;
    using System.Collections.Generic;

    public class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions<ExpenseTrackerDbContext> options) : base(options) { }

        public DbSet<Expense> Expenses { get; set; }
    }

}
