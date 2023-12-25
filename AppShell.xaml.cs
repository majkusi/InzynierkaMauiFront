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
            InitializeComponent();
        }
    }
}
