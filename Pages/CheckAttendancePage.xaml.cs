using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using InzynierkaMauiFront.Features;
using InzynierkaMauiFront.Models;

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
                    var api = RestService.For<IPostItemsApi>("http://localhost:5159");
                    var model = new CompareFacesRequestModel
                    {
                        SourceImage = new StreamPart(await photo.OpenReadAsync(), "image.jpg", "image/jpeg")
                    };

                    var result = await api.CompareFaces(new List<StreamPart> { model.SourceImage });
                    // Przetwarzanie wyniku
                    Console.WriteLine(result);
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
            string id = HttpUtility.UrlDecode(query["classId"].ToString());
        }
    }
}