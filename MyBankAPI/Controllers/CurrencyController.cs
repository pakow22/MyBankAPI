using Microsoft.AspNetCore.Mvc;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Services.CuurencyService;
using MyBankAPI.Services.LoanApplicationService;

namespace MyBankAPI.Controllers
{
    [Route("api/[controller]")]
    public class CurrencyController : Controller
    {
        #region private fields
        private readonly ICurrencyService _currencyService;
        #endregion

        #region ctor
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        #endregion

        #region methods
        [HttpGet]
        public IEnumerable<Currency> GetAllCurrencies()
        {
            return _currencyService.GetAllCrrencies();
        }
        [HttpGet("{id}")]
        public Currency GetCurrencyById(int id)
        {
            return _currencyService.GetCurrencyById(id);
        }
        [HttpPost]
        public ActionResult AddCurrency([FromBody] CurrencyModel currencyModel)
        {
            _currencyService.AddCurrency(currencyModel);
            return Ok(currencyModel);
        }
        [HttpPut]
        public ActionResult UpdateCurrency(int Id , [FromBody] CurrencyModel currency)
        {
            _currencyService.UpdateCurrency(Id,currency);
            return Ok(currency);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCurrency(int id)
        {
            _currencyService.DeleteCurrency(id);
            return Ok();
        }
        #endregion
    }
}
