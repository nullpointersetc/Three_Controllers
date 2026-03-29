namespace NullPointersEtc.Three_Controllers.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get=>m_Name; set=>m_Name=value; }
        public string Email { get => m_Email; set => m_Email = value; }
        private string m_Name = string.Empty;
        private string m_Email = string.Empty;
    }

    public class User
    {
        public static User From(UserDTO from) => new User { Id = from.Id, Name = from.Name, Email = from.Email };
        public UserDTO AsDTO() => new UserDTO { Id = this.Id, Name = this.Name, Email = this.Email };

        public int Id { get; set; }
        public string Name { get => m_Name; set => m_Name = value; }
        public string Email { get => m_Email; set => m_Email = value; }
        private string m_Name = string.Empty;
        private string m_Email = string.Empty;
    }
}
