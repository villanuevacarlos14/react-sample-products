using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using product.inventory.data;
using product.inventory.data.models;
using product.inventory.dto;

namespace product.inventory.service
{
    public interface IUserService
    {
        Task<UserDto> GetUser(string Username, string Password);
    }
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserDto> GetUser(string Username, string Password)
        {
            // var user = await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Username == Username).ConfigureAwait(false);
            // if (user is not null)
            // {
            //     var passwordVerificationResult = new PasswordHasher<object>().VerifyHashedPassword(null, user.Password, Password);

            //     if (passwordVerificationResult == PasswordVerificationResult.Success)
            //     {
            //         return this._mapper.Map<User, UserDto>(user);
            //     }
            // }

            return null;
        }
    }
}