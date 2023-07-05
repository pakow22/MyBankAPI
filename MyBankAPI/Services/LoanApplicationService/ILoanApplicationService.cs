using Microsoft.AspNetCore.Mvc;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Services.LoanApplicationService
{
    public interface ILoanApplicationService
    {
        List<LoanApplicationModel> GetLoanApplications();
        LoanApplicationModel GetLoanApplicationById(int id);
        LoanApplicationModel AddLoanApplication(LoanApplicationModel application);
        LoanApplicationModel UpdateLoanApplication(int Id, LoanApplicationModel application);
        IEnumerable<LoanApplicationModel> DeleteLoanApplication(int id);

    }
}
