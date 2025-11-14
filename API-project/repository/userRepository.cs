using System.Collections.Specialized;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json;
using UserModel;
namespace Repository
{
    public class UserRepository
    {
        string _filePath = "user.txt";
        public IEnumerable<User> GetUsers()
        {
            List<User> list = new List<User>();
            string? currentUserInFile;
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    list.Add(user);
                }
            }
            return list;
        }

        public User? GetUserById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user;
                }
                return null;
            }
        }
        public User addNewUser( User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(_filePath).Count();
            user.UserId = (int)(numberOfUsers + 1);
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(_filePath, userJson + Environment.NewLine);
            return  user;
        }

        public User? Login( User value)
        {
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Gmail == value.Gmail && user.Password == value.Password)
                        return user;
                }
            }
            return null;
        }
        
        public User update(int id, User value)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(_filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(_filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(value));
                System.IO.File.WriteAllText(_filePath, text);
            }
            return (value);
        }
        public void Delete(int id)
        {
        }
    }
}
