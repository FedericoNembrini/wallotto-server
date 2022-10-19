using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocoLayer.Models;
using ServiceLayer;
using wallotto_server.Extensions;
using wallotto_server.Filters.ActionFilters;
using wallotto_server.Models;

namespace wallotto_server.Controllers
{
    public class TransactionController : ControllerBaseExtended
    {
        public TransactionController(IConfiguration configuration, IService service, IMapper mapper) : base(configuration, service, mapper)
        {
        }

        #region Get Methods

        [HttpGet]
        public IActionResult GetTranstactions(DateTime? fromDate = null, DateTime? toDate = null)
        {
            try
            {
                List<TransactionDTO> transactions =
                    _mapper.Map<List<TransactionDTO>>(_service.TransactionRepository.GetUserTransactions(User.GetIdentityId(), fromDate, toDate));

                return new JsonResult(transactions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Put Methods

        #endregion

        #region Post Methods

        [HttpPost]
        [ServiceFilter(typeof(IsDataValidFilterAttribute))]
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

        #region Delete Methods

        [HttpDelete]
        [ServiceFilter(typeof(HasDataFilterAttribute))]
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
