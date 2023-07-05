using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Services.CuurencyService
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCrrencies();
        Currency GetCurrencyById(int id);
        Currency AddCurrency(CurrencyModel currency);
        Currency UpdateCurrency(int Id ,CurrencyModel currency);
        IEnumerable<Currency> DeleteCurrency(int id);
    }
}
