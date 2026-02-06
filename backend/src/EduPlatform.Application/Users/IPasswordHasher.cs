using System;
using System.Collections.Generic;
using System.Text;

namespace EduPlatform.Application.Users
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(object user, string hashedPassword, string providedPassword);
    }
}
