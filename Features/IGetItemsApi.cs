
using InzynierkaMauiFront.Models;
using Refit;

namespace InzynierkaMauiFront.Features;

public interface IGetItemsApi
{
    [Get("/Course/GetCourse")]
    Task<List<CourseModel>> GetCourses();

    [Get("/Course/GetById/{id}")]
    Task<int> GetCourseById(int id);
}