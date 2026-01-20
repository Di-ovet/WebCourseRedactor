namespace EduPlatform.Domain.Users;

public class User
{
    public Guid UserId { get; private set; }
    public string PasswordHash { get; private set; }
    public string LastName { get; private set; }
    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string Email { get; private set; }

    public User(string f, string i, string o, string mail, string pass)
    {
        UserId = Guid.NewGuid();
        LastName = f;
        FirstName = i;
        MiddleName = o;
        PhoneNumber = null;
        Email = mail;
        PasswordHash = (pass);
    }
}
