using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;

namespace LoginBaseApp.ViewModels;

public class ProfileViewModel : BindableObject
{
    private string _fullName = "שם לדוגמה";
    public string FullName { get => _fullName; set { _fullName = value; OnPropertyChanged(); } }

    private string _email = "example@email.com";
    public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }

    private ImageSource _profileImageSource = "default_profile.png"; // Resources/Images/default_profile.png
    public ImageSource ProfileImageSource { get => _profileImageSource; set { _profileImageSource = value; OnPropertyChanged(); } }

    private string SavedImagePath => Path.Combine(FileSystem.AppDataDirectory, "profile.jpg");

    public ICommand PickPhotoCommand { get; }
    public ICommand CapturePhotoCommand { get; }
    public ICommand ResetPhotoCommand { get; }

    public ProfileViewModel()
    {
        LoadSavedImage();
        PickPhotoCommand = new Command(async () => await PickPhotoAsync());
        CapturePhotoCommand = new Command(async () => await CapturePhotoAsync());
        ResetPhotoCommand = new Command(ResetPhoto);
    }

    private void LoadSavedImage()
    {
        if (File.Exists(SavedImagePath))
            ProfileImageSource = ImageSource.FromFile(SavedImagePath);
    }

    private async Task SaveImageAsync(FileResult file)
    {
        using var inStream = await file.OpenReadAsync();
        using var outStream = File.Open(SavedImagePath, FileMode.Create, FileAccess.Write);
        await inStream.CopyToAsync(outStream);
        ProfileImageSource = ImageSource.FromFile(SavedImagePath);
    }

    private async Task PickPhotoAsync()
    {
        var result = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions { Title = "בחר תמונה" });
        if (result != null) await SaveImageAsync(result);
    }

    private async Task CapturePhotoAsync()
    {
        if (!MediaPicker.Default.IsCaptureSupported) return;
        var result = await MediaPicker.Default.CapturePhotoAsync();
        if (result != null) await SaveImageAsync(result);
    }

    private void ResetPhoto()
    {
        if (File.Exists(SavedImagePath)) File.Delete(SavedImagePath);
        ProfileImageSource = "default_profile.png";
    }
}
