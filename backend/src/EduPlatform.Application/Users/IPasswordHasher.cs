using System;
using System.Collections.Generic;
using System.Text;

namespace EduPlatform.Application.Users
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
