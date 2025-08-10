using LoginBaseApp.Models;

namespace LoginBaseApp.Service
{
    /// <summary>
    /// מחלקת ניהול משתמשים בזיכרון (DB פיקטיבי).
    /// </summary>
    public class UserRepository 
    {
        private readonly List<User> users = new List<User>();

        public UserRepository()
        {
            // נתוני התחלה לדוגמה
            users.Add(new User { Username = "admin", Password = "Admin123" });
            users.Add(new User { Username = "guest", Password = "Guest1" });
        }

        /// <summary>
        /// הוספת משתמש חדש
        /// </summary>
        public void AddUser(User user)
        {
            users.Add(user);
        }

        /// <summary>
        /// אחזור משתמש לפי שם משתמש
        /// </summary>
        public User? GetUserByUsername(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }

        /// <summary>
        /// מחיקת משתמש לפי שם משתמש
        /// </summary>
        public bool DeleteUser(string username)
        {
            var user = GetUserByUsername(username);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            return false;
        }

        /// <summary>
        /// החזרת כל המשתמשים
        /// </summary>
        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
