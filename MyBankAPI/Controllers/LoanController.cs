using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Services.LoanApplicationService;

namespace MyBankAPI.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        #region private fields
        private readonly ILoanApplicationService _loanApplicationService;
        #endregion
        #region ctor
        public LoanController(ILoanApplicationService loanApplicationService)
        {
           _loanApplicationService = loanApplicationService;
        }
        #endregion
        #region methods

        [HttpGet]
        public IEnumerable<LoanApplicationModel> GetLoanApplications()
        {
           return _loanApplicationService.GetLoanApplications();
        } 
        [HttpGet("{id}")]
        public LoanApplicationModel GetLoanApplicationById(int id)
        {
            return _loanApplicationService.GetLoanApplicationById(id);
        }
        [HttpPost]
        public ActionResult AddLoanApplication(LoanApplicationModel application)
        {
            _loanApplicationService.AddLoanApplication(application);
            return Ok(application);
        }
        [HttpPut]
        public ActionResult UpdateLoanApplication(int Id,[FromBody]LoanApplicationModel application)
        {
            _loanApplicationService.UpdateLoanApplication(Id, application);
            return Ok(application);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteLoanApplication(int id)
        {
            var applications =  _loanApplicationService.DeleteLoanApplication(id);
            return Ok(applications);
        }
        #endregion
    }
}
