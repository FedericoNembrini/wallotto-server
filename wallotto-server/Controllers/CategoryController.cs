using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocoLayer.Models;
using ServiceLayer;
using wallotta_server.Models;

namespace wallotta_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBaseExtended
    {
        public CategoryController(IService service, IMapper mapper) : base(service, mapper)
        {
        }

        #region Get Methods

        #endregion

        #region Put Methods

        [HttpPut]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                Category categoryToCreate = _mapper.Map<Category>(categoryDTO);

                _service.CategoryRepository.Add(categoryToCreate);
                _service.Commit();

                return new JsonResult(categoryToCreate);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }

        #endregion

        #region Post Methods

        #endregion

        #region Delete Methods

        [HttpDelete]
        public IActionResult DeleteCategory([FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                Category categoryToDelete = _service.CategoryRepository.Find(new object[] { categoryDTO.Id });

                _service.CategoryRepository.Delete(categoryToDelete);
                _service.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }

        #endregion
    }
}
