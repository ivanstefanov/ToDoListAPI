using System;

namespace PaymentsAPI.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public int EditedBy { get; set; }
        public int UserId { get; set; }
        
    }
}
