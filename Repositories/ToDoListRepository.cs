using Microsoft.EntityFrameworkCore;

using PaymentsAPI.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Repositories
{
    public class ToDoListRepository : ToDoDbContext, IToDoListRepository
    {
        public ToDoListRepository(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        public async Task<List<ToDoList>> GetAllLists()
        {
            return await ToDoLists.ToListAsync();
        }

        public async Task AddToDoLists()
        {
            var list = new ToDoList()
            {
                Title = "test list",
                AddedOn = DateTime.Now,
                EditedBy = 1,
                EditedOn = DateTime.Now,
                UserId = 1
            };

            await ToDoLists.AddAsync(list);
            await SaveChangesAsync();            
        }
    }
}
