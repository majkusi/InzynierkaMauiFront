using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InzynierkInzynierkaMauiFrontaApi.Models;

public class TeacherLoginModel( string password, string email)
{
    [Key] public int TeacherLoginId { get; set; }

    public string Password { get; set; } = password;

    [ForeignKey("TeacherModel")] public string Email { get; set; } = email;
}