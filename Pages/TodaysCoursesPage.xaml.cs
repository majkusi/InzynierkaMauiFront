using System.Runtime.InteropServices.JavaScript;
using InzynierkaMauiFront.Features;
using InzynierkaMauiFront.Models;
using Refit;

namespace InzynierkaMauiFront.Pages
{
    public partial class TodaysCoursesPage : ContentPage
    {
        private readonly IGetItemsApi _apiService;
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5159" : "http://localhost:5159";

        public TodaysCoursesPage()
        {
            _apiService = RestService.For<IGetItemsApi>(BaseAddress);
            LoadCourses();

            InitializeComponent();
        }

        private async void LoadCourses()
        {
            var allCourses = await _apiService.GetCourses();

            // Filtruj zajęcia na bieżący dzień
            var today = DateTime.Today;
            var todaysCourses = allCourses.Where(course => course.DateOfClass.Date == today);

            coursesCollectionView.ItemsSource = todaysCourses.ToList();
        }
        private async void CheckAttendanceButton_OnClicked(object? sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is CourseModel selectedCourse)
            {
                int classId = selectedCourse.CourseId; 
                
                await Shell.Current.GoToAsync($"checkAttendancePage?classId={classId}");
            }
        }

    
    }
}