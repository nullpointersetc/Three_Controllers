#region
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
    public int ID
    {
        get => myID ?? throw new InvalidOperationException(nameof(ID) + " has not been set");
        set => myID = value > 0 ? value : throw new ArgumentOutOfRangeException(paramName: nameof(ID), "positive integer required");
    }

    public string Name
    {
        get => myName ?? throw new InvalidOperationException(nameof(Name) + " has not been set");
        set => myName = string.IsNullOrEmpty(value)
            ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: " cannot be null or empty.")
            : value;
    }

    public string EMail
    {
        get => myEMail ?? throw new InvalidOperationException(nameof(EMail) + " has not been set");
        set => myEMail = string.IsNullOrEmpty(value) ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: "must not be null or empty") : value;
    }

    private int? myID;
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
        get => myName ?? throw new InvalidOperationException(nameof(Name) + " has not been set");
        set => myName = string.IsNullOrEmpty(value)
            ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: " cannot be null or empty.")
            : value;
    }

    public string EMail
    {
        get => myEMail ?? throw new InvalidOperationException(nameof(EMail) + " has not been set");
        set => myEMail = string.IsNullOrEmpty(value) ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: "must not be null or empty") : value;
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

    public int ID
    {
        get => myID ?? throw new InvalidOperationException(nameof(ID) + " has not been set");
        set => myID = value > 0 ? value : throw new ArgumentOutOfRangeException(paramName: nameof(ID), "positive integer required");
    }

    public string Name
    {
        get => myName ?? throw new InvalidOperationException(nameof(Name) + " has not been set");
        set => myName = string.IsNullOrEmpty(value)
            ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: " cannot be null or empty.")
            : value;
    }

    public string EMail
    {
        get => myEMail ?? throw new InvalidOperationException(nameof(EMail) + " has not been set");
        set => myEMail = string.IsNullOrEmpty(value) ? throw new ArgumentOutOfRangeException(paramName: nameof(Name), message: "must not be null or empty") : value;
    }

    private int? myID;
    private string? myName;
    private string? myEMail;
}

#endregion

