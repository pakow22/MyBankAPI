using Microsoft.AspNetCore.Mvc;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Services.CuurencyService;
using MyBankAPI.Services.LoanStatusService;

namespace MyBankAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoanStatusController : Controller
    {

        #region private fields
        private readonly ILoanStatusService _loanStatusService;
        #endregion

        #region ctor
        public LoanStatusController(ILoanStatusService loanStatusService)
        {
            _loanStatusService = loanStatusService;
        }
        #endregion

        #region methods
        [HttpGet]
        public IEnumerable<LoanStatus> GetAllLoanStatuses()
        {
            return _loanStatusService.GetAllLoanStatuses();
        }
        [HttpGet("{id}")]
        public LoanStatus GetLoanStatusById(int id)
        {
            return _loanStatusService.GetLoanStatusById(id);
        }
        [HttpPost]
        public ActionResult AddLoanStatus(int id,[FromBody]LoanStatusModel loanStatusModel)
        {
            _loanStatusService.AddLoanStatus(loanStatusModel);
            return Ok(loanStatusModel);
        }
        [HttpPut]
        public ActionResult UpdateLoanStatus(int id,[FromBody] LoanStatusModel loanStatusModel)
        {
            _loanStatusService.UpdateLoanStatus(id,loanStatusModel);
            return Ok(loanStatusModel);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteLoanStatus(int id)
        {
            _loanStatusService.DeleteLoanstatus(id);
            return Ok();
        }
        #endregion
    }
}
