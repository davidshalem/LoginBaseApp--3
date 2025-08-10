namespace LoginBaseApp;
using LoginBaseApp.Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // הגדרת דפי הניווט של האפליקציה
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));

    }
}
