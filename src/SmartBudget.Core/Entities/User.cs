namespace SmartBudget.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        // We store a password hash, not plaintext.
        public string PasswordHash { get; set; } = string.Empty;
    }
}
