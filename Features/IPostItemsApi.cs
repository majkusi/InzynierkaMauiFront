
using InzynierkInzynierkaMauiFrontaApi.Models;
using InzynInzynierkaMauiFrontierkaApi.Models;
using Refit;

namespace InzynierkaMauiFront.Features;

public interface IPostItemsApi
{
    [Post("/Attendance/NewAttendance/{studentId}/{courseId}/{isPresent}")]
    Task AttendanceModel(bool isPresent, int studentId, int courseId);
    [Multipart]
    [Post("/api/compare/{courseId}")]
    Task<string> CompareFaces([AliasAs("courseId")] int courseId, [AliasAs("sourceImage")] IEnumerable<StreamPart> streams);
 
}