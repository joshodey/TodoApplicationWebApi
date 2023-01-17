using MyTodo_Application.DTO;

namespace MyTodo_Application.Services
{
    public interface IUser
    {
        UserModel GetOneUser(string username);
        string AddUser(RegisterUser user);
        Task<UserModel> GetAllUsers(string username);
        Task<UserModel> GetUsersByRole(string role);
        void UpdateUser(UserModel user);
        string DeleteUser(string username);


    }
}
