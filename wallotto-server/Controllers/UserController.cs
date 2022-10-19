using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PocoLayer.Models;
using ServiceLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wallotto_server.Models;

namespace wallotto_server.Controllers
{
    public class UserController : ControllerBaseExtended
    {
        public UserController(IConfiguration configuration, IService service, IMapper mapper) : base(configuration, service, mapper)
        {
        }

        #region Get Methods

        #endregion

        #region Put Methods

        #endregion

        #region Post Methods

        [HttpPost]
        [AllowAnonymous]
        public UserDTO CreateUser(string userName, string password)
        {
            try
            {
                User userToCreate = new()
                {
                    UserName = userName,
                    Password = password
                };

                _service.UserRepository.Add(userToCreate);
                _service.Commit();

                return _mapper.Map<UserDTO>(userToCreate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult LoginUser([FromBody] UserDTO userDTO)
        {
            try
            {
                User user = _service.UserRepository.GetUser(userDTO.UserName, userDTO.Password);

                if (user is null)
                    return Unauthorized();

                return Ok(GenerateToken(user));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Private Methods

        private string GenerateToken(User user)
        {
            string issuer = _configuration["JwtConfig:validIssuer"];
            string audience = _configuration["JwtConfig:validAudience"];
            byte[] key = Encoding.ASCII.GetBytes(_configuration["JwtConfig:secret"]);
            DateTime expire = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["JwtConfig:expiresIn"]));

            SecurityTokenDescriptor securityTokenDescriptor = new()
            {
                Claims = new Dictionary<string, object>()
                {
                    { "Id", user.Id },
                    { ClaimTypes.Name, user.UserName }
                },
                Expires = expire,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }

        #endregion
    }
}
