using System.Collections.Generic;
using System.Threading.Tasks;
using AppRetry.API.DTO;
using AppRetry.API.Entities;
using AppRetry.API.Interface.IRepositories;
using AppRetry.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRetry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IMapper _imapper;
        public UserController(IUserRepository userRepository, IMapper iMapper)
        {
            _iUserRepository = userRepository;
            _imapper = iMapper;
        }

        /// <summary>
        /// Return a list of users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterUsers()
        {
            var data = await _iUserRepository.ObterUsers();
            return Ok(data);
        }


        /// <summary>
        /// Creates a User.
        /// </summary>
        /// <remarks>
        ///     POST /User
        ///     {
        ///        "name": "string",
        ///        "email": "string",
        ///        "password": "string"
        ///     }
        /// </remarks>
        /// <param name="user"></param>
        /// <returns>A newly created User</returns>
        /// <response code="201">Returns the newly created user</response>
        /// <response code="400">If the user is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SaveUser([FromBody] UserDTO user)
        {
            user.Email = user.Email.ToLower();
            if (await _iUserRepository.UserExists(user.Email))
                return BadRequest("Email já existe");

            var createUser = _imapper.Map<User>(user);
            var createdUser = await _iUserRepository.SaveUser(createUser);

            return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _iUserRepository.GetUser(id);
            if (user.Equals(null))
                return NotFound();

            return user;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> AlterUser(long id, [FromBody] User user)
        {
            if (id != user.UserId)
                return BadRequest();

            await _iUserRepository.AlterUser(user);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> SmallChangeUser(long id, [FromBody] User user)
        {
            if (id != user.UserId)
                return BadRequest();

            await _iUserRepository.AlterUser(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            var user = await _iUserRepository.GetUser(id);

            if (user.Equals(null))
                return NotFound();

            await _iUserRepository.DeleteUser(id);

            return NoContent();
        }
    }
}