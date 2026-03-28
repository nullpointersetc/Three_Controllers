namespace NullPointersEtc.Three_Controllers.Services
{
    using User = NullPointersEtc.Three_Controllers.Models.UserDTO;
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User? GetByEmail(string email);
        void Register(User user);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public IEnumerable<User> GetAll() => _users;

        public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

        public User? GetByEmail(string email) =>
            _users.FirstOrDefault(u => u.Email == email);

        public void Register(User user) => _users.Add(user);

        public void Delete(int id) => _users.RemoveAll(u => u.Id == id);
    }
}
