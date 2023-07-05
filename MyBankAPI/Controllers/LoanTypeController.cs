using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Services.LoanStatusService;
using MyBankAPI.Services.LoanTypeService;

namespace MyBankAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class LoanTypeController : Controller
    {
        #region private fields
        private readonly ILoanTypeService _loanTypeService;
        #endregion

        #region ctor
        public LoanTypeController(ILoanTypeService loanTypeService)
        {
            _loanTypeService = loanTypeService;
        }
        #endregion

        #region methods
        [HttpGet]
        public IEnumerable<LoanType> GetAllLoanTypes()
        {
            return _loanTypeService.GetAllLoanTypes();
        }
        [HttpGet("{id}")]
        public LoanType GetLoanTypeById(int id)
        {
            return _loanTypeService.GetLoanTypeById(id);
        }
        [HttpPost]
        public ActionResult AddLoanType(LoanTypeModel loanTypeModel)
        {
            _loanTypeService.AddLoanType(loanTypeModel);
            return Ok(loanTypeModel);
        }
        [HttpPut("{Id}")]
        public ActionResult UpdateLoanType([FromBody] LoanTypeModel loanTypeModel)
        {
            _loanTypeService.UpdateLoanType(loanTypeModel);
            return Ok(loanTypeModel);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteLoanStatus(int id)
        {
            _loanTypeService.DeleteLoanType(id);
            return Ok();
        }
        #endregion
    }
}
