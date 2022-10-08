using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocoLayer.Models;
using ServiceLayer;
using wallotta_server.Models;

namespace wallotta_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBaseExtended
    {
        public TransactionController(IService service, IMapper mapper) : base(service, mapper)
        {
        }

        #region Get Methods

        #endregion

        #region Put Methods

        [HttpPut]
        public IActionResult CreateTransaction([FromBody] TransactionDTO transactionDTO)
        {
            try
            {
                Transaction transactionToCreate = _mapper.Map<Transaction>(transactionDTO);

                _service.TransactionRepository.Add(transactionToCreate);
                _service.Commit();

                return new JsonResult(transactionToCreate);
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
        public IActionResult DeleteTransaction([FromBody] TransactionDTO transactionDTO)
        {
            try
            {
                Transaction transactionToDelete = _service.TransactionRepository.Find(new object[] { transactionDTO.Id });

                _service.TransactionRepository.Delete(transactionToDelete);
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
