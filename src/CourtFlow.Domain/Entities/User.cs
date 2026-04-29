using System.Text.RegularExpressions;
using CourtFlow.Domain.Enums;
using CourtFlow.Domain.Services;
using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public UserRole Role { get; private set; }
    public DateTime CreatedAt { get; private set; }

    [Obsolete("For EF core only.", error:true)]
    protected User()
    {

    }

    private User(string name, EmailAddress email, PhoneNumber phone, PasswordHash password)
    {
        ValidateCommon(name);

        Name = name;
        Email = email;
        Phone = phone;
        PasswordHash = password;
        Role = UserRole.Member;
        CreatedAt = DateTime.UtcNow;
    }

    public static User Create(string name, EmailAddress email, PhoneNumber phone, string PlainPassword,
        IPasswordHasher hasher)
    {
        ValidatePassword(PlainPassword);
        var hash = hasher.Hash(PlainPassword);
        return new User(name, email, phone, hash);
    }

    private void ValidateCommon(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Invalid name");
        if (name.Length < 3 || name.Length > 100)
            throw new ArgumentException("Name must be between 3 and 100 characters.");
    }

    private static void ValidatePassword(string password)
    {
        var isValid = Regex.IsMatch(password,
            @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[#?!@$%^&*-]).{8,}$");

        if (!isValid)
            throw new ArgumentException("Weak password");
    }

}