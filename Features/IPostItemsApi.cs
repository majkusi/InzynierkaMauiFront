using InzynierkaMauiFront.Models;
using Refit;

namespace InzynierkaMauiFront.Features;

public interface IPostItemsApi
{
    [Post("/Attendance/NewAttendance/{studentId}/{courseId}/{isPresent}")]
    Task AttendanceModel(bool isPresent, int studentId, int courseId);
    [Multipart]
    [Post("/api/compare")]
    Task<string> CompareFaces([AliasAs("sourceImage")] IEnumerable<StreamPart> streams);
}