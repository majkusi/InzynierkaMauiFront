using InzynierkaMauiFront.Pages;

namespace InzynierkaMauiFront
{
    public partial class AppShell : Shell
    {
        public AppShell()
        
        {
            Routing.RegisterRoute("loginPage",typeof(LoginPage));
            Routing.RegisterRoute("todaysCoursesPage", typeof(TodaysCoursesPage));
            Routing.RegisterRoute("checkAttendancePage", typeof(CheckAttendancePage));
            Routing.RegisterRoute("mainMenuPage",typeof(MainMenuPage));
            Routing.RegisterRoute("attendanceRaportPage",typeof(AttendanceRaportPage));
            Routing.RegisterRoute("userDetailsPage",typeof(UserDetailsPage));
            Routing.RegisterRoute("courseDetailsPage",typeof(CourseDetailsPage));
            InitializeComponent();
        }
    }
}
