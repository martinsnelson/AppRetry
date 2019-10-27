using System.Runtime.Serialization;

namespace AppRetry.API.DTO
{
    public class UserDTO
    {
        public long UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}