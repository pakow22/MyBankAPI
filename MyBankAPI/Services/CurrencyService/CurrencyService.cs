using AutoMapper;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Repositories.CuurencyRepository;

namespace MyBankAPI.Services.CuurencyService
{
    public class CurrencyService : ICurrencyService
    {
        #region private fields
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public CurrencyService(ICurrencyRepository currencyRepository,IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods
        public Currency AddCurrency(CurrencyModel currencyModel)
        {
            Currency currency = new()
            {
                Name = currencyModel.Name,
                DateCreated = DateTime.Now,
            };
            _currencyRepository.Add(currency);
            return currency;
        }

        public IEnumerable<Currency> DeleteCurrency(int id)
        {
            var currency = _currencyRepository.GetById(id);
            currency.DateDeleted = DateTime.Now;
            _currencyRepository.Delete(currency);
            return _currencyRepository.GetAll();
        }

        public List<Currency> GetAllCrrencies()
        {
            var currencies = _currencyRepository.GetAll().Where(x => x.DateDeleted == null);
            return currencies.ToList();
        }

        public Currency GetCurrencyById(int id)
        {
            return _currencyRepository.GetById(id);
        }

        public Currency UpdateCurrency(int id, CurrencyModel currencyModel)
        {
            var currency = GetCurrencyById(id);
            currency.Name = currencyModel.Name;
            currency.DateChanged = DateTime.Now;
            _currencyRepository.Update(currency);
            return currency;
        }
        #endregion
    }
}
