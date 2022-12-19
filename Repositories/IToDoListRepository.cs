using PaymentsAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Repositories
{
    public interface IToDoListRepository
    {
        Task<List<ToDoList>> GetAllLists();
        Task AddToDoLists();
    }
}
