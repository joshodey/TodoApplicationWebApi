using MyTodo.BL.Interface;

namespace MyTodo.BL.Models
{
    public class IdMethod : IIdMethod
    {
        public static string IdRegister(string statusname, int n)
        {
            return statusname.Substring(0, 3) + n;
        }
    }
}