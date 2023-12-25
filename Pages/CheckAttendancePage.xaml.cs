using InzynierkaMauiFront.Models;
using System.ComponentModel;
using System.Web;
using InzynierkaMauiFront.Features;

namespace InzynierkaMauiFront.Pages
{

    public partial class CheckAttendancePage : IQueryAttributable, INotifyPropertyChanged
    {

        public CheckAttendancePage()
        {
            
            InitializeComponent();
            
        }
        private async void OnCheckAttendanceClicked(object sender, EventArgs e)
        {
            // Call the Face API service method for checking attendance
            
        }
        public CourseModel Course { get; private set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            string id = HttpUtility.UrlDecode(query["classId"].ToString());
            Console.WriteLine("GOWNO JEBANE NAME W CHECK ATTENDANCE PAGE  "+id);
        }

            
    }
} 