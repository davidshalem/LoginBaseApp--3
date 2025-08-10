using LoginBaseApp.ViewModels;

namespace LoginBaseApp.Views;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage(RegistrationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
