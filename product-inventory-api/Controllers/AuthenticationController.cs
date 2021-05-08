using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using product.inventory.dto;
using product.inventory.dto.AuthenticationModel;
using product.inventory.service;

namespace product_inventory_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IUserService userService, IConfiguration configuration, ILogger<AuthenticationController> logger)
        {
            _userService = userService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthModel request)
        {
            var account = await _userService.GetUser(request.UserName, request.Password).ConfigureAwait(false);

            if (account == null)
            {
                _logger.LogWarning("Username or password is incorrect");
                return Unauthorized(new { message = "Username or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = this.BuildUserToken(account);

            var token = tokenHandler.CreateToken(tokenDescriptor);

            _logger.LogInformation("Ok");
            //add generic response later.
            return Ok(new
            {
                Token = tokenHandler.WriteToken(token),
                UserName = account.Username
            });
        }

        private SecurityTokenDescriptor BuildUserToken(UserDto user)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(AuthenticationClaims.UserId, user.Id.ToString()),
                    new Claim(AuthenticationClaims.Username, user.Username)
                }),
                Expires = DateTime.Now.AddDays(7),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._configuration["Authentication:Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
        }
    }
}