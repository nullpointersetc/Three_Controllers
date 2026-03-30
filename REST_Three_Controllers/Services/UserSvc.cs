using DatabaseContext = NullPointersEtc.ThreeControllers.Data.Context;
using User_t = NullPointersEtc.ThreeControllers.Models.User;
using Guid_t = System.Guid;

namespace NullPointersEtc.ThreeControllers.Services;

public interface IUserService
{
    IEnumerable<User_t> GetAll();
    User_t? GetById(Guid_t id);
    User_t? GetByEmail(string email);
    void Add(User_t user);
    void Delete(Guid_t id);
}

public class UserService : IUserService
{
    public UserService(DatabaseContext context) =>
        myContext = context;

    private readonly DatabaseContext myContext;

    public IEnumerable<User_t> GetAll() => myContext.Users.ToList();

    public User_t? GetById(Guid_t id) =>
        myContext.Users.FirstOrDefault(u => u.ID == id);

    public User_t? GetByEmail(string email) =>
        myContext.Users.FirstOrDefault(u => u.EMail == email);

    public void Add(User_t user)
    {
        myContext.Users.Add(user);
        myContext.SaveChanges();
    }

    public void Update(User_t user)
    {
        myContext.Users.Update(user);
        myContext.SaveChanges();
    }

    public void Delete(Guid_t id)
    {
        var user = myContext.Users.FirstOrDefault(u => u.ID == id);
        if (user != null)
        {
            myContext.Users.Remove(user);
            myContext.SaveChanges();
        }
    }
}
