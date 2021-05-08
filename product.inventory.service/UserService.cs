using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using product.inventory.data;
using product.inventory.data.models;
using product.inventory.data.repository;
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
        private readonly IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<UserDto> GetUser(string Username, string Password)
        {
            var user = await _repository.GetAll().AsNoTracking().SingleOrDefaultAsync(x => x.Username == Username).ConfigureAwait(false);
            if (user is not null)
            {
                var passwordVerificationResult = new PasswordHasher<object>().VerifyHashedPassword(null, user.Password, Password);

                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    return this._mapper.Map<User, UserDto>(user);
                }
            }

            return null;
        }
    }
}