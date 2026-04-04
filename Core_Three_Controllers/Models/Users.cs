#region "Users.cs"
using Guid = System.Guid;
using Unicode = Microsoft.EntityFrameworkCore.UnicodeAttribute;
using StringLength = System.ComponentModel.DataAnnotations.StringLengthAttribute;

namespace NullPointersEtc.ThreeControllers.Models;

public class User
{
    public User() { }

    public User(UserCreateDTO from)
    {
        myName.Name = from.Name;
        myEMail.EMail = from.EMail;
    }

    public User(UserDTO from)
    {
        myID.ID = from.ID;
        myName.Name = from.Name;
        myEMail.EMail = from.EMail;
    }

    public Guid ID
    {
        get => myID.ID;
        set => myID.ID = value;
    }

    [Unicode(unicode: true),
        StringLength(
        maximumLength: UserName.MaxLength,
        MinimumLength = UserName.MinLength)]
    public string Name
    {
        get => myName.Name;
        set => myName.Name = value;
    }

    [Unicode(unicode: true),
        StringLength(
        maximumLength: UserEMail.MaxLength,
        MinimumLength = UserEMail.MinLength)]
    public string EMail
    {
        get => myEMail.EMail;
        set => myEMail.EMail = value;
    }

    private UserID myID;
    private UserName myName;
    private UserEMail myEMail;
}

public class UserCreateDTO
{
    public UserCreateDTO() { }

    [Unicode(unicode: true),
        StringLength(
        maximumLength: UserName.MaxLength,
        MinimumLength = UserName.MinLength)]
    public string Name
    {
        get => myName.Name;
        set => myName.Name = value;
    }

    [Unicode(unicode: true),
        StringLength(
        maximumLength: UserEMail.MaxLength,
        MinimumLength = UserEMail.MinLength)]
    public string EMail
    {
        get => myEMail.EMail;
        set => myEMail.EMail = value;
    }

    private UserName myName;
    private UserEMail myEMail;
}

public class UserDTO
{
    public UserDTO() { }

    public UserDTO(User from)
    {
        myID.ID = from.ID;
        myName.Name = from.Name;
        myEMail.EMail = from.EMail;
    }

    public Guid ID
    {
        get => myID.ID;
        set => myID.ID = value;
    }

    [Unicode(unicode: true),
        StringLength(
        maximumLength: UserName.MaxLength,
        MinimumLength = UserName.MinLength)]
    public string Name
    {
        get => myName.Name;
        set => myName.Name = value;
    }

    [Unicode(unicode: true),
        StringLength(
        maximumLength: UserEMail.MaxLength,
        MinimumLength = UserEMail.MinLength)]
    public string EMail
    {
        get => myEMail.EMail;
        set => myEMail.EMail = value;
    }

    private UserID myID;
    private UserName myName;
    private UserEMail myEMail;
}

internal struct UserID
{
    public Guid ID
    {
        get => myID ??
            throw new ArgumentNullException(
                paramName: nameof(ID),
                message: "has not been set");

        set => myID = value;
    }
    private Guid? myID;
}

internal struct UserName
{
    [Unicode(unicode: true),
        StringLength(
        maximumLength: MaxLength,
        MinimumLength = MinLength)]
    internal string Name
    {
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length < MinLength
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > MaxLength
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than " +
                MaxLength.ToString() + " characters")
            : value;
    }

    internal const int MinLength = 1, MaxLength = 100;

    private string? myName;
}

internal struct UserEMail
{
    internal string EMail
    {
        get => myEMail ??
            throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "has not been set");

        set => myEMail = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "cannot be null")
            : value.Length < MinLength
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be empty")
            : value.Length > MaxLength
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be longer than " +
                MaxLength.ToString() + " characters")
            : !value.Contains('@')
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "must contain an '@' character")
            : value;
    }

    internal const int MinLength = 1, MaxLength = 100;

    private string? myEMail;
}

#endregion "Users.cs"
