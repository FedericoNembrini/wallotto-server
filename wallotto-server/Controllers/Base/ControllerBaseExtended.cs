using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace wallotto_server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class ControllerBaseExtended : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        protected readonly IService _service;
        protected readonly IMapper _mapper;

        public ControllerBaseExtended(IConfiguration configuration, IService service, IMapper mapper) : base()
        {
            _configuration = configuration;
            _service = service;
            _mapper = mapper;
        }
    }
}
