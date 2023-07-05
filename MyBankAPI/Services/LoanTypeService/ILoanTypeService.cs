using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Services.LoanTypeService
{
    public interface ILoanTypeService
    {
        List<LoanType> GetAllLoanTypes();
        LoanType GetLoanTypeById(int id);
        LoanType AddLoanType(LoanTypeModel loanStatus);
        LoanType UpdateLoanType(LoanTypeModel loanStatus);
        IEnumerable<LoanType> DeleteLoanType(int id);
    }
}
