using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBaseApp.Service
{
	/// <summary>
	/// מימוש של שירות ההתחברות המשתמש ברשימת משתמשים מקומית (Mock) לצורכי פיתוח ובדיקה.
	/// </summary>
	public class DBMokup : ILoginService
	{
		// רשימה המשמשת כמסד נתונים מדמה
		List<Models.User> users = new List<Models.User>();

		/// <summary>
		/// בנאי המאתחל את "מסד הנתונים" עם משתמשים לדוגמה.
		/// </summary>
		public DBMokup()
		{
			users.Add(new Models.User { Username = "admin", Password = "admin" });
			users.Add(new Models.User { Username = "user1", Password = "password1" });
			users.Add(new Models.User { Username = "user2", Password = "password2" });
		}

		/// <summary>
		/// מבצע אימות פרטי משתמש מול רשימת המשתמשים המקומית.
		/// </summary>
		/// <param name="username">שם המשתמש לבדיקה.</param>
		/// <param name="password">הסיסמה לבדיקה.</param>
		/// <returns>אמת (true) אם נמצא משתמש עם פרטים תואמים, אחרת שקר (false).</returns>
		public bool Login(string username, string password)
		{
			// חיפוש המשתמש הראשון ברשימה שתואם לשם המשתמש והסיסמה שהתקבלו
			var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
			// אם נמצא משתמש (התוצאה אינה null), ההתחברות הצליחה
			return user != null;
		}
	}
}