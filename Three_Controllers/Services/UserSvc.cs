namespace NullPointersEtc.Three_Controllers.Services
{
    using DatabaseContext = NullPointersEtc.Three_Controllers.Data.DatabaseContext;
    using User_t = NullPointersEtc.Three_Controllers.Models.User;
    public interface IUserService
    {
        IEnumerable<User_t> GetAll();
        User_t? GetById(int id);
        User_t? GetByEmail(string email);
        void Add(User_t user);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        public UserService(DatabaseContext context)
        {
            m_context = context;
        }

        private readonly DatabaseContext m_context;

        public IEnumerable<User_t> GetAll() => m_context.Users.ToList();

        public User_t? GetById(int id) => m_context.Users.FirstOrDefault(u => u.Id == id);

        public User_t? GetByEmail(string email) =>
            m_context.Users.FirstOrDefault(u => u.Email == email);

        public void Add(User_t user)
        {
            m_context.Users.Add(user);
            m_context.SaveChanges();
        }

        public void Update(User_t user)
        {
            m_context.Users.Update(user);
            m_context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = m_context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                m_context.Users.Remove(user);
                m_context.SaveChanges();
            }
        }
    }
}
