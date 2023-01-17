using Microsoft.EntityFrameworkCore;
using MyTodo_Application.DTO;
using MyTodo_Application.Helper;
using MyTodo_Application.Services;

namespace MyTodo_Application.Implementations
{
    public class Todo : ITodo
    {
        private readonly ApplicationContext _context;

        public Todo(ApplicationContext context)
        {
            _context = context;
        }
        public void AddTodo(MyTodoDto todo)
        {
            var mytodo = new MyTodo()
            {
                TaskId = Guid.NewGuid().ToString().Substring(0, 4),
                TaskStatus = todo.TaskStatus,
                TaskName = todo.TaskName
            };
            _context.Add(mytodo);
            _context.SaveChanges();
        }

        public string DeleteTodo(string taskId)
        {
            var todo = _context.TodoTable.FirstOrDefault(x => x.TaskId == taskId);
            if (todo == null)
            {
                return "Todo does not exist";
            }

            _context.Remove(todo);
            _context.SaveChanges();
            return "Successful";
        }

        public async Task<PageList<MyTodoDto>> GetTodo(PaginationParameters parameters)
        {
            //var res = await _context.TodoTable.Where(x => x.Id == parameters.PageNumber).ToListAsync();


            var todo = await _context.TodoTable.Select(x =>
            new MyTodoDto
            {
                TaskId = x.TaskId,
                TaskName = x.TaskName,
                TaskStatus = x.TaskStatus,
                TaskDate = x.TaskDate
            }).ToListAsync();

            return PageList<MyTodoDto>.ToPagedList(todo, parameters.PageNumber, parameters.PageSize);
        }

        public void UpdateTodo(MyTodoDto todo)
        {
            var mytodo = _context.TodoTable.FirstOrDefault(x => x.TaskId == todo.TaskId);
            mytodo.TaskId = todo.TaskId;
            mytodo.TaskDate = todo.TaskDate;
            mytodo.TaskStatus = todo.TaskStatus;
            mytodo.TaskName = todo.TaskName;
            
            _context.Update(mytodo);
            _context.SaveChanges();
        }

        public MyTodoDto GetTodoByTaskId(string taskId)
        {
            var todo = _context.TodoTable.FirstOrDefault(x =>
            x.TaskId == taskId);
            if (todo == null)
            {
                return null;
            }
            var todo1 = new MyTodoDto
            {
                TaskId = taskId,
                TaskName = todo.TaskName,
                TaskStatus = todo.TaskStatus,
                TaskDate = todo.TaskDate
            };
            return todo1;
        }

        public  Task<List<MyTodoDto>> GetTodoByTaskStatus(string taskstatus)
        {
            var todo = _context.TodoTable.Where(x => x.TaskStatus == taskstatus).Select(x =>
            new MyTodoDto
            {
                TaskId = x.TaskId,
                TaskName = x.TaskName,
                TaskStatus = x.TaskStatus,
                TaskDate = x.TaskDate
            }).ToListAsync();

            return todo;
        }


        public Task<List<MyTodoDto>> GetTodoByTaskName(string taskname)
        {
            var todo = _context.TodoTable.Where(x => x.TaskName == taskname).Select(x =>
            new MyTodoDto
            {
                TaskId = x.TaskId,
                TaskName = x.TaskName,
                TaskStatus = x.TaskStatus,
                TaskDate = x.TaskDate
            }).ToListAsync();

            return todo;
        }

    }

}

