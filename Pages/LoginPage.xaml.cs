// Import necessary namespaces
using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InzynierkaMauiFront.Pages
{
    public partial class LoginPage : ContentPage
    {
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5159" : "http://localhost:5159";

        private bool _isLoggedIn = false;

        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    OnPropertyChanged(nameof(IsLoggedIn));
                }
            }
        }

        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Set the BindingContext of the LoginPage to itself
            BindingContext = this;
        }

        private async void LoginButton_OnClicked(object? sender, EventArgs e)
        {
            // Get the entered login and password from the Entry controls
            string login = loginEntry.Text;
            string password = passwordEntry.Text;

            // Perform the login by calling the backend API
            bool isLoginSuccessful = await PerformLoginAsync(login, password);

            if (isLoginSuccessful)
            {
                // If login is successful, navigate to the main menu page
                IsLoggedIn = true;
                await Shell.Current.GoToAsync("/mainMenuPage");
            }
            else
            {
                // If login fails, display an error message
                IsLoggedIn = false;
                await DisplayAlert("Login Failed", "Invalid login or password", "OK");
            }
        }

        private async Task<bool> PerformLoginAsync(string login, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                // Adjust the API endpoint URL based on your backend
                string apiUrl = BaseAddress;

                // Prepare the login request data
                var requestData = new { Login = login, Password = password };
                var jsonContent = new StringContent(JsonSerializer.Serialize(requestData), Encoding.UTF8, "application/json");

                // Send the login request to the backend
                HttpResponseMessage response = await client.PostAsync(apiUrl, jsonContent);

                // Check the response status
                if (response.IsSuccessStatusCode)
                {
                    // You may also want to parse the response content if needed
                    // For example: var result = await response.Content.ReadAsStringAsync();

                    return true; // Login successful
                }
                // Inside PerformLoginAsync after response.IsSuccessStatusCode check
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Login failed. Error: {errorContent}");
                    return true;
                }
            }
        }
    }
}
