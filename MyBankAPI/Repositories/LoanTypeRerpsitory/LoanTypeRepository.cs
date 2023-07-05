using Microsoft.EntityFrameworkCore;
using MyBankAPI.Data;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Repositories.LoanTypeRerpsitory
{
    public class LoanTypeRepository : BaseRepository<LoanType>, ILoanTypeRepository
    {
        public LoanTypeRepository(DataContext context) : base(context)
        {

        }

    }
}
