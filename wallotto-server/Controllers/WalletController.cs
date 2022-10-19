using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PocoLayer.Models;
using ServiceLayer;
using wallotto_server.Filters.ActionFilters;
using wallotto_server.Models;

namespace wallotto_server.Controllers
{
    public class WalletController : ControllerBaseExtended
    {
        public WalletController(IConfiguration configuration, IService service, IMapper mapper) : base(configuration, service, mapper)
        {
        }

        #region Get Methods

        #endregion

        #region Put Methods

        [HttpPut]
        [ServiceFilter(typeof(IsDataValidFilterAttribute))]
        public IActionResult UpdateWallet([FromBody] WalletDTO walletDTO)
        {
            try
            {
                Wallet walletUpdated = _mapper.Map<Wallet>(walletDTO);
                Wallet walletToUpdate = _service.WalletRepository.Find(new object[] { walletDTO.Id });

                _service.WalletRepository.Attach(walletToUpdate);

                walletToUpdate.Name = walletUpdated.Name;
                walletToUpdate.ExcludeFromReport = walletUpdated.ExcludeFromReport;

                _service.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }

        #endregion

        #region Post Methods

        [HttpPost]
        [ServiceFilter(typeof(IsDataValidFilterAttribute))]
        public IActionResult CreateWallet([FromBody] WalletDTO walletDTO)
        {
            try
            {
                Wallet walletToCreate = _mapper.Map<Wallet>(walletDTO);

                _service.WalletRepository.Add(walletToCreate);
                _service.Commit();

                return new JsonResult(_mapper.Map<WalletDTO>(walletToCreate));
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
        public IActionResult DeleteWallet([FromBody] WalletDTO walletDTO)
        {
            try
            {
                Wallet walletToDelete = _service.WalletRepository.Find(new object[] { walletDTO.Id });

                _service.WalletRepository.Delete(walletToDelete);
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
