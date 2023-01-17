using MyTodo_Application.DTO;
using MyTodo_Application.Services;

namespace MyTodo_Application.Implementations
{
    public class User : IUser
    {
        private ApplicationContext _context;
        public User(ApplicationContext context)
        {
            _context = context;
        }
        public string AddUser(RegisterUser user)
        {
            bool checkuser = GetOneUser(user.UserName.ToLower()).Equals(user.UserName.ToLower());
            if (checkuser)
            {
                return null;
            }
            _context.Add(user);
            _context.SaveChanges();
            return "AccountCreated";
        }


        public string DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetAllUsers(string username)
        {
            throw new NotImplementedException();
        }

        public UserModel GetOneUser(string username)
        {
            var user = _context.TodoList.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public Task<UserModel> GetUsersByRole(string role)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
