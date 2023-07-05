using Microsoft.EntityFrameworkCore;
using MyBankAPI.Data;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Repositories;

namespace MyBankAPI.Repository.LoanApplicationRepository
{
    public class LoanApplicationRepository : BaseRepository<LoanApplication>,ILoanApplicationRepository
    {
       
    }
}
