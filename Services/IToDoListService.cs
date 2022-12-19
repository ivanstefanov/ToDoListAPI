using Microsoft.IdentityModel.Tokens;

using PaymentsAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Services
{
    public interface IToDoListService
    {
        Task<List<ToDoList>> GetToDoLists();
        Task AddToDoLists();        
    }
}
