using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InzynierkaMauiFront.Models;
using InzynInzynierkaMauiFrontierkaApi.Models;

namespace InzynierkaApi.Models;

public class AttendanceModel
{
    [Key]
    public int AttendanceId { get; set; }
    public bool IsPresent { get; set; }
    [ForeignKey("StudentModel")]
    public int StudentId { get; set; }
    public StudentModel Student { get; set; }
    [ForeignKey("CourseModel")]
    public int CourseId { get; set; }
    public CourseModel Course { get; set; }

}