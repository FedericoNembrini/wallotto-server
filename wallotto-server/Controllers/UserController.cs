using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocoLayer.Models;
using ServiceLayer;
using wallotta_server.Models;

namespace wallotta_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBaseExtended
    {
        public UserController(IService service, IMapper mapper) : base(service, mapper)
        {
        }

        #region Get Methods

        #endregion

        #region Post Methods

        [HttpPut]
        public IActionResult CreateUser(string userName, string password)
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

                return new JsonResult(_mapper.Map<UserDTO>(userToCreate));
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }

        #endregion
    }
}
