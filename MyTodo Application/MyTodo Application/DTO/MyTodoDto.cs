using System.ComponentModel.DataAnnotations;

namespace MyTodo_Application.DTO
{
    public class MyTodoDto
    {
        public string? TaskName { get; set; }
        public string? TaskStatus { get; set; }
        public DateTime TaskDate { get; set; }
        public string? TaskId { get; set; }
    }
}
