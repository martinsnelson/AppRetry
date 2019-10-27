using System.ComponentModel.DataAnnotations;

namespace AppRetry.API.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}