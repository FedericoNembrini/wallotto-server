using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocoLayer.Models;
using ServiceLayer;
using wallotto_server.Filters.ActionFilters;
using wallotto_server.Models;

namespace wallotto_server.Controllers
{
    public class CategoryController : ControllerBaseExtended
    {
        public CategoryController(IConfiguration configuration, IService service, IMapper mapper) : base(configuration, service, mapper)
        {
        }

        #region Get Methods

        #endregion

        #region Put Methods

        #endregion

        #region Post Methods

        [HttpPost]
        [ServiceFilter(typeof(IsDataValidFilterAttribute))]
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

        #region Delete Methods

        [HttpDelete]
        [ServiceFilter(typeof(HasDataFilterAttribute))]
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
