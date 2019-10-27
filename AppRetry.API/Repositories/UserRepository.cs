using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRetry.API.DTO;
using AppRetry.API.Entities;
using AppRetry.API.Infra.Context;
using AppRetry.API.Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace AppRetry.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppRetryContext _context;

        public UserRepository(AppRetryContext appRetryContext)
        {
            _context = appRetryContext;
        }


        public async Task<IEnumerable<UserDTO>> ObterUsers()
        {
            // throw new System.NotImplementedException();
            var dados = await _context.User.Select(x => new UserDTO
            {
                UserId = x.UserId,
                Name = x.Name,
                Email = x.Email
            }).AsNoTracking().ToListAsync();

            return dados;
        }


        public async Task<User> SaveUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }


        public async Task<User> GetUser(long id)
        {
            var test = await _context.User.FindAsync(id);
            return test;
        }


        public async Task<User> AlterUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User> SmallChangeUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return user;
        }


        public async Task<bool> DeleteUser(long id)
        {
            var tarefa = await _context.User.FindAsync(id);

            _context.User.Remove(tarefa);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> UserExists(string userName)
        {
            if (await _context.User.AnyAsync(x => x.Email == userName))
                return true;

            return false;
        }
    }
}