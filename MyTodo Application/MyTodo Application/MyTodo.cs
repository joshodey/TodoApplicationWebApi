using System.ComponentModel.DataAnnotations;

namespace MyTodo_Application
{
    public class MyTodo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Limit exceeded`")]
        public string? TaskName { get; set; }
        [Required]
        [MaxLength(25, ErrorMessage = "Limit exceeded`")]
        public string? TaskStatus { get; set; }
        public DateTime TaskDate { get; set; }
        public string TaskId { get; set; }
    }
}
