using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginBaseApp.Service
{
	/// <summary>
	/// ממשק (Interface) המגדיר את החוזה עבור שירותי התחברות.
	/// כל מחלקה שתממש ממשק זה חייבת לספק לוגיקת התחברות.
	/// </summary>
	public interface ILoginService
	{
		/// <summary>
		/// פעולה לאימות פרטי משתמש.
		/// </summary>
		/// <param name="username">שם המשתמש.</param>
		/// <param name="password">סיסמת המשתמש.</param>
		/// <returns>מחזירה אמת (true) אם ההתחברות הצליחה, אחרת שקר (false).</returns>
		public bool Login(string username, string password);
	}
}