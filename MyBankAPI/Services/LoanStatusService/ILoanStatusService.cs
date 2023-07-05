using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Services.LoanStatusService
{
    public interface ILoanStatusService
    {
        List<LoanStatus> GetAllLoanStatuses();
        LoanStatus GetLoanStatusById(int id);
        LoanStatus AddLoanStatus(LoanStatusModel loanStatus);
        LoanStatus UpdateLoanStatus(int id,LoanStatusModel loanStatus);
        IEnumerable<LoanStatus> DeleteLoanstatus(int id);
    }
}
