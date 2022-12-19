using Microsoft.EntityFrameworkCore;

using PaymentsAPI.Models;

namespace PaymentsAPI
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {

        }

        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}