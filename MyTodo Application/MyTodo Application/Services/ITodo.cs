using MyTodo_Application.DTO;
using MyTodo_Application.Helper;

namespace MyTodo_Application.Services
{
    public interface ITodo
    {
        void AddTodo(MyTodoDto todo);
        void UpdateTodo(MyTodoDto todo);
        string DeleteTodo(string taskId);
        Task<PageList<MyTodoDto>> GetTodo(PaginationParameters parameters);
        MyTodoDto GetTodoByTaskId(string taskId);
        Task<List<MyTodoDto>> GetTodoByTaskStatus(string taststatus);
        Task<List<MyTodoDto>> GetTodoByTaskName(string taskname);
    }
}
