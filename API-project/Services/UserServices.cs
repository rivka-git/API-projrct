using System.Text.Json;
using UserModel;
using Repository;
namespace Services
{


    public class UserServices
    {
        UserRepository r=new UserRepository();
        public IEnumerable<User> GetUsers()
        {
            return r.GetUsers();
        }
        public User? GetUserById(int id)
        {
            return r.GetUserById(id);
        }
        public User addNewUser(User user)
        {
            return r.addNewUser(user);
        }

        public User? Login(User value)
        {
            return r.Login(value);
        }
        public User update(int id, User value)
        {
            return r.update(id, value);
        }
        public void Delete(int id)
        {
           r.Delete(id);
        }

    }
}
