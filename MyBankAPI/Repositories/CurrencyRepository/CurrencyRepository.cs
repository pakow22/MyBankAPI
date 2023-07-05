using Microsoft.EntityFrameworkCore;
using MyBankAPI.Data;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Repositories.CuurencyRepository
{
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DataContext context) : base(context)
        {

        }
    }
}
