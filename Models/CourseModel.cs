using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InzynierkaMauiFront.Models
{
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }
        public string NameOfClass { get; set; }
        public DateTime DateOfClass { get; set; }

        [ForeignKey("TeacherModel")]
        public int TeacherId { get; set; }
        public List<int> StudentsId { get; set; } = new List<int>();

        public CourseModel(string nameOfClass, int teacherId, DateTime dateOfClass)
        {
            NameOfClass = nameOfClass;
            TeacherId = teacherId;
            DateOfClass = dateOfClass;
        }
    }
}