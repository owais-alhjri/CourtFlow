using CourtFlow.Domain.Enums;
using CourtFlow.Domain.ValueObjects;

namespace CourtFlow.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public EmailAddress Email { get; private set; }
    public PhoneNumber Phone { get; private set; }
    public Password Password { get; private set; }
    public UserRole Role { get; private set; }

    protected User()
    {

    }

    public User(string name, EmailAddress email, PhoneNumber phone, Password password)
    {
        ValidateCommon(name);

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        Password = password;
        Role = UserRole.Member;
    }

    private void ValidateCommon(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 100)
            throw new ArgumentException("Invalid name");


    }

}