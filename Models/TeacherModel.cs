using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InzynInzynierkaMauiFrontierkaApi.Models
{
    public class TeacherModel(string firstName, string lastName, string department, string email)
    {
        [Key]
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Department { get; set; } = department;
        public string Email { get; set; } = email;
    }
}
