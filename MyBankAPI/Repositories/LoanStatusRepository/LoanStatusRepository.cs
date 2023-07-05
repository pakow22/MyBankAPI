using Microsoft.EntityFrameworkCore;
using MyBankAPI.Data;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Repositories.LoanStatusRepository
{
    public class LoanStatusRepository : BaseRepository<LoanStatus> , ILoanStatusRepository
    {
     
    }
}
