using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PaymentsAPI.Models;
using PaymentsAPI.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController: ControllerBase
    {
        private readonly IToDoListService _toDoListService;

        public ToDoListController(IToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        /// <summary>
        /// Returns list with ToDo lists
        /// </summary>        
        [HttpGet]
        public async Task<ActionResult<List<ToDoList>>> GetToDoList()
        {
            return await _toDoListService.GetToDoLists();     
        }

        /// <summary>
        /// Adds an item to the ToDo list
        /// </summary>        
        [HttpPost]
        public async Task<ActionResult> AddToDoList()
        {
            await _toDoListService.AddToDoLists();

            return Ok();
        }
    }
}
