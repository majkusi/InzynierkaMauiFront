using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InzynierkaMauiFront.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_OnClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("todaysCoursesPage");
    }
}