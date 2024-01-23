using InzynierkInzynierkaMauiFrontaApi.Models;
using Refit;

namespace InzynierkaMauiFront.Features;

public interface ILoginApi
{
    [Post("/Login/GiveCredentials")]
    Task<string> Login(TeacherLoginModel teacher);
}