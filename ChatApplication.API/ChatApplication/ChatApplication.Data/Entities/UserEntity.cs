namespace ChatApplication.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        
        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}