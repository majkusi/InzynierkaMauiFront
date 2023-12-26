
using InzynierkaMauiFront.Models;
using InzynInzynierkaMauiFrontierkaApi.Models;
using Refit;

namespace InzynierkaMauiFront.Features;

public interface IGetItemsApi
{
    // COURSES
    [Get("/Course/GetCourse")]
    Task<List<CourseModel>> GetCourses();

    [Get("/Course/GetById/{id}")]
    Task<int> GetCourseById(int id);

    [Get("/Course/GetByDate/{date}")]
    Task<DateTime> GetCourseDate(DateTime date);

    // ATTENDANCE
    [Get("/Attendance/GetByCourse/{courseId")]
    Task<int> GetAttendanceByCourse(int courseId);

    [Get("/Attendance/GetByStudent/{studentId}")]
    Task<int> GetAttendanceByStudentId(int studentId);


    // STUDENTS

    [Get("/GetAll")]
    Task<List<StudentModel>> GetStudents();

    [Get("/GetById/{id}")]
    Task<int> GetStudentById(int id);

    // TEACHERS
    [Get("/Teacher/GetTeachers")]
    Task<List<TeacherModel>> GetTeachers();

    [Get("/Teacher/GetTeacherById/{id}")]
    Task<int> GetTeacherById(int id);

}