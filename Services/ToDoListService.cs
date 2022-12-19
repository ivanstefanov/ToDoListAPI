using Microsoft.IdentityModel.Tokens;

using PaymentsAPI.Models;
using PaymentsAPI.Repositories;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsAPI.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _toDoListRepository;
        public ToDoListService(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<List<ToDoList>> GetToDoLists()
        {
            return await _toDoListRepository.GetAllLists();
        }
        
        public async Task AddToDoLists()
        {
            await _toDoListRepository.AddToDoLists();    
        }
    }
}
