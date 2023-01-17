using Microsoft.EntityFrameworkCore;

namespace MyTodo_Application
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options): base(options) { }

        public DbSet<MyTodo> TodoTable { get; set; }
        public DbSet<UserModel> TodoList { get; set; }
    }
}
