using SQLite;

namespace HeroChatClient.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(16), Unique]
        public string Username { get; set; }

        [MaxLength(18)]
        public string Password { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(32), Unique]
        public string Email { get; set; }

        [MaxLength(16)]
        public string Country { get; set; }

        [MaxLength(3)]
        public string Age { get; set; }
    }
}
