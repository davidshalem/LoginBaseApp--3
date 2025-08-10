using LoginBaseApp.Models;
using LoginBaseApp.Service;
using System.Windows.Input;
using LoginBaseApp.Views;
namespace LoginBaseApp.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly UserRepository userRepository;

        public RegistrationViewModel(UserRepository repo)
        {
            userRepository = repo;
            RegisterCommand = new Command(RegisterUser);
        }

        // --- Properties לקשירת ה-UI ---
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-18);

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        // גיל מחושב
        public int Age => DateTime.Now.Year - BirthDate.Year -
                         (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);

        // Command לכפתור הרשמה
        public ICommand RegisterCommand { get; }

        private async void RegisterUser()
        {
            // בדיקות תקינות
            if (string.IsNullOrWhiteSpace(Username) || char.IsDigit(Username[0]) || Username.Contains(" "))
            {
                Message = "שם משתמש לא יכול להתחיל בספרה או להכיל רווחים";
                return;
            }

            if (!Password.Any(char.IsUpper) || !Password.Any(char.IsDigit))
            {
                Message = "סיסמה חייבת להכיל אות גדולה ומספר";
                return;
            }

            if (Age < 18)
            {
                Message = "הגיל חייב להיות מעל 18";
                return;
            }

            // יצירת משתמש חדש והוספה ל-DB הפיקטיבי
            var newUser = new User
            {
                Username = Username,
                Password = Password
                // אפשר להוסיף כאן שדות נוספים למודל
            };

            userRepository.AddUser(newUser);
            Message = "נרשמת בהצלחה!";
            await Shell.Current.GoToAsync(nameof(ProfilePage));
        }
    }
}
