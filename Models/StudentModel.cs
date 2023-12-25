using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InzynInzynierkaMauiFrontierkaApi.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AlbumId { get; set; }
        public string Department { get; set; }
        public string FieldOfStudy { get; set; }
        public List<int> CourseId { get; set; } = new List<int>();

        public StudentModel(string firstName, string lastName, int albumId, string department, string fieldOfStudy)
        {
            FirstName = firstName;
            LastName = lastName;
            AlbumId = albumId;
            Department = department;
            FieldOfStudy = fieldOfStudy;
        }
    }
}
