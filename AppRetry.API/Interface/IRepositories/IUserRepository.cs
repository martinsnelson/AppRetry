using System.Collections.Generic;
using System.Threading.Tasks;
using AppRetry.API.DTO;
using AppRetry.API.Entities;

namespace AppRetry.API.Interface.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserListDTO>> ObterUsers();
        Task<User> SaveUser(User user);
        Task<User> GetUser(long id);
        Task<User> AlterUser(User user);
        Task<User> SmallChangeUser(User user);
        Task<bool> DeleteUser(long id);
        Task<bool> UserExists(string userName);
        // IEnumerable<UserDTO> ObterUsers();
        // Task<User> ObterUser(long id);
        // Task<User> InserirUser(User user);
        // // Task<UserDTO> SaveUser(UserDTO user);
        // Task<User> AlterarUser(User user);
        // Task<User> PutUser(User user);
        // Task<bool> DeletarUser(long id);
    }
}