#region "Users.cs"
using Guid_t = System.Guid;

namespace NullPointersEtc.ThreeControllers.Models;

public class User
{
    public User()
    {
        myID = null;
        myName = null;
        myEMail = null;
    }

    public User(UserCreateDTO from)
    {
        myID = null;
        myName = from.Name;
        myEMail = from.EMail;
    }

    public User(UserDTO from)
    {
        myID = from.ID;
        myName = from.Name;
        myEMail = from.EMail;
    }

    public Guid_t ID
    {
        get => myID ??
            throw new ArgumentNullException(
                paramName: nameof(ID),
                message: "has not been set");

        set => myID = value;
    }

    public string Name
    {
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than 100 characters")
            : value;
    }

    public string EMail
    {
        get => myEMail ??
            throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "has not been set");

        set => myEMail = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be longer than 100 characters")
            : value;
    }

    private Guid_t? myID;
    private string? myName;
    private string? myEMail;
}

public class UserCreateDTO
{
    public UserCreateDTO()
    {
        myName = null;
        myEMail = null;
    }

    public string Name
    {
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than 100 characters")
            : value;
    }

    public string EMail
    {
        get => myEMail ??
            throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "has not been set");

        set => myEMail = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be longer than 100 characters")
            : value;
    }

    private string? myName;
    private string? myEMail;
}

public class UserDTO
{
    public UserDTO()
    {
        myID = null;
        myName = null;
        myEMail = null;
    }

    public UserDTO(User from)
    {
        myID = from.ID;
        myName = from.Name;
        myEMail = from.EMail;
    }

    public Guid_t ID
    {
        get => myID ??
            throw new ArgumentNullException(
                paramName: nameof(ID),
                message: "has not been set");

        set => myID = value;
    }

    public string Name
    {
        get => myName ??
            throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "has not been set");

        set => myName = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(Name),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(Name),
                message: "cannot be longer than 100 characters")
            : value;
    }

    public string EMail
    {
        get => myEMail ??
            throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "has not been set");

        set => myEMail = value is null
            ? throw new ArgumentNullException(
                paramName: nameof(EMail),
                message: "cannot be null")
            : value.Length == 0
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be empty")
            : value.Length > 100
            ? throw new ArgumentOutOfRangeException(
                paramName: nameof(EMail),
                message: "cannot be longer than 100 characters")
            : value;
    }

    private Guid_t? myID;
    private string? myName;
    private string? myEMail;
}

#endregion "Users.cs"
