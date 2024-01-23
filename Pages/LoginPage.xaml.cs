// Import necessary namespaces
using InzynierkaMauiFront.Features;
using InzynierkInzynierkaMauiFrontaApi.Models;
using Refit;


namespace InzynierkaMauiFront.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly ILoginApi _login;
        public LoginPage(ILoginApi login)
        {
            _login = login;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Shell.SetTabBarIsVisible(this, false);// set false in second page, set true in first page

        }
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                TeacherLoginModel teacher = new TeacherLoginModel(passwordEntry.Text, loginEntry.Text);
                var token = await _login.Login(teacher);
                if (!string.IsNullOrEmpty(token))
                {
                    await SecureStorage.SetAsync("auth_token", token);
                    await Navigation.PushAsync(new MainMenuPage());
                }
                else
                {
                    await DisplayAlert("Login Failed", "Invalid credentials", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "An error occurred during login.", "OK");
            }
        }
    }
}
