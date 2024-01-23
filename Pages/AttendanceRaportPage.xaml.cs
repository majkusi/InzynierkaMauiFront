using InzynierkaMauiFront.Features;
using Refit;

namespace InzynierkaMauiFront.Pages;

public partial class AttendanceRaportPage : ContentPage
{
    public static string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5159" : "http://localhost:5159";
    private readonly IGetItemsApi _apiService;
    public AttendanceRaportPage()
	{
        _apiService = RestService.For<IGetItemsApi>(BaseAddress);
        InitializeComponent();
	}

    private void FindAttendanceByStudentAlbumBtn_OnClicked(object? sender, EventArgs e)
    { 
      LoadAttendanceList(StudentAlbumNumberEntry.Text);
    }




    private async void LoadAttendanceList(string albumId)
    {
        var attendanceList = await _apiService.GetAttendanceByStudentId(albumId);
        attendanceCollectionView.ItemsSource = attendanceList;
    }
}