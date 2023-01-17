using System.ComponentModel.DataAnnotations;

namespace MyTodo_Application
{
    public class UserModel
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "limit exceeded")]
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        [MinLength(2)]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MinLength(2)]
        [MaxLength(25)]
        public string LastName { get; set; }
    }
}
