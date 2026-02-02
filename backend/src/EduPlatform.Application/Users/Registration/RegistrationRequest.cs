using System;
using System.Collections.Generic;
using System.Text;

namespace EduPlatform.Application.Registration
{
    public class RegistrationRequest
    {
        public string lastName { get; init; }
        public string firstName { get; init; }
        public string middleName { get; init; } 
        public string email { get; init; }
        public string password { get; init; }
        
    }
}
