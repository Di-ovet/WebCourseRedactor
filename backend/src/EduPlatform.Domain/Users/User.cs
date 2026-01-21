namespace EduPlatform.Domain.Users;

public sealed class User
{
    private User() { }

    public Guid UserId { get; private set; }
    public string PasswordHash { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string FirstName { get; private set; } = null!;
    public string? MiddleName { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string Email { get; private set; } = null!;
    public DateTime CreatedAtUtc { get; private set; }

    public static User Create(
        string lastName,
        string firstName,
        string middleName,
        string email,
        string passwordHash,
        DateTime createdAtUtc)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Неправильно введена фамилия", nameof(lastName));

        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("Неправильно введено имя", nameof(firstName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Неправильно введена почта", nameof(email));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Неправильно введен пароль", nameof(passwordHash));

        return new User
        {
            UserId = Guid.NewGuid(),
            LastName = lastName,
            FirstName = firstName,
            MiddleName = middleName,
            Email = email,
            PasswordHash = passwordHash,
            PhoneNumber = null,
            CreatedAtUtc = createdAtUtc
        };
    }
}
