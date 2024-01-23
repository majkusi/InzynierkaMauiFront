using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using InzynierkaMauiFront.Features;
using InzynierkaMauiFront.Models;
using InzynInzynierkaMauiFrontierkaApi.Models;

namespace InzynierkaMauiFront.Pages
{
    public partial class CheckAttendancePage : IQueryAttributable, INotifyPropertyChanged
    {
        private string classId;
        private int Id;
        private string _result;
        private readonly IGetItemsApi _apiService;
        private StudentModel studentId;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
                DisplayAlertIfResultChanged(); // Invoke the alert whenever Result changes
            }
        }
        public static string BaseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5159" : "http://localhost:5159";
        public CheckAttendancePage()
        {
            _apiService = RestService.For<IGetItemsApi>(BaseAddress);
            InitializeComponent();
            BindingContext = this;  // Set the binding context to the page itself
            LoadStudents();
        }


        private List<StudentModel> _studentsList;
        public List<StudentModel> StudentsList
        {
            get { return _studentsList; }
            set
            {
                _studentsList = value;
                OnPropertyChanged(nameof(StudentsList));
            }
        }
        private async void LoadStudents()
        {
                // Check if classId can be parsed to an integer
                if (int.TryParse(classId, out int courseId))
                {
                    try
                    {
                        var allCourses = await _apiService.GetAllStudentsInCourse(courseId);
                        Console.WriteLine($"Number of students: {allCourses.Count}");
                        StudentsList = allCourses.ToList();
                        studentsCollectionView.ItemsSource = StudentsList.ToList();
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error while loading students: {ex.Message}");
                        // Handle the exception as needed
                    }
                }
                else
                {
                    // Handle the case where classId cannot be parsed as an integer
                    Console.WriteLine("Invalid classId format.");
                }
        }
        private void DisplayAlertIfResultChanged()
        {
            if (!string.IsNullOrEmpty(Result))
            {
                // Display alert here
                MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    studentId = await _apiService.GetStudentById(Result);
                    await DisplayAlert("Znaleziony student", $"Result: {studentId.FirstName} {studentId.LastName}", "OK");

                });
            }
        }

        private async void OnCheckAttendanceClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Rozpoczęcie zdjęcia");
            try
            {
                var options = new MediaPickerOptions
                {
                    Title = "Zrób zdjęcie"
                };

                var photo = await MediaPicker.CapturePhotoAsync(options);
                Console.WriteLine("Zdjęcie wykonane");
                if (photo != null)
                {
                    var api = RestService.For<IPostItemsApi>(BaseAddress);
                    var model = new CompareFacesRequestModel
                    {
                        SourceImage = new StreamPart(await photo.OpenReadAsync(), "image.jpg", "image/jpeg")
                    };

                    // Convert classId to int before passing it
                    if (int.TryParse(classId, out int courseId))
                    {
                        Result = await api.CompareFaces(courseId: courseId, streams: new List<StreamPart> { model.SourceImage });
                        
                        Console.WriteLine(Result);
                    }
                    else
                    {
                        // Handle the case where classId cannot be parsed as an integer
                        Console.WriteLine("Invalid classId format.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Obsługa wyjątków
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            classId = HttpUtility.UrlDecode(query["classId"].ToString());
            LoadStudents(); // Call LoadStudents after setting classId
        }

    }






}