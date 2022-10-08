using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace wallotta_server.Controllers
{
    public class ControllerBaseExtended : ControllerBase
    {
        protected readonly IService _service;
        protected readonly IMapper _mapper;

        public ControllerBaseExtended(IService service, IMapper mapper) : base()
        {
            _service = service;
            _mapper = mapper;
        }
    }
}
