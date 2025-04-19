namespace GPSTracker.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        private User(Guid id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        public static User Create(string username, string email)
        {
            User user = new(Guid.NewGuid(), username, email);
            return user;
        }

        public void SetPassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }
    }
}
