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
            try
            {
                var courses = await _apiService.GetCourses();
                coursesCollectionView.ItemsSource = courses;
            }
            catch (ApiException ex)
            {
                // Handle exception if needed
            }
        }
        private async void CheckAttendanceButton_OnClicked(object? sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is CourseModel selectedCourse)
            {
                int classId = selectedCourse.CourseId;
                
                Console.WriteLine(classId + " GOWNO JEBANE W TODAYS");
                
                await Shell.Current.GoToAsync($"checkAttendancePage?classId={classId}");
            }
        }

    
    }
}