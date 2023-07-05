using AutoMapper;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Repositories.LoanStatusRepository;
using MyBankAPI.Repositories.LoanTypeRerpsitory;

namespace MyBankAPI.Services.LoanTypeService
{
    public class LoanTypeService : ILoanTypeService
    {
        #region private fields
        private readonly ILoanTypeRepository _loanTypeRepository;
        private readonly IMapper _mapper;
        #endregion

        #region ctor
        public LoanTypeService(ILoanTypeRepository loanTypeRepository,IMapper mapper)
        {
            _loanTypeRepository = loanTypeRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods
        public LoanType AddLoanType(LoanTypeModel loanStatusModel)
        {
            LoanType loanType = new()
            {
                Name = loanStatusModel.Name,
                DateCreated = DateTime.Now,
            };
            _loanTypeRepository.Add(loanType);
            return loanType;
        }
        public IEnumerable<LoanType> DeleteLoanType(int id)
        {
            //var loanType = _loanTypeRepository.GetById(id);
            //_loanTypeRepository.Delete(loanType);
            //return _loanTypeRepository.GetAll();
            return default;
        }

        public List<LoanType> GetAllLoanTypes()
        {
            var loanTypes = _loanTypeRepository.GetAll().Where(x => x.DateDeleted == null);
            return loanTypes.ToList();
        }

        public LoanType GetLoanTypeById(int id)
        {
            var loanType = _loanTypeRepository.GetById(id);
            return loanType;
        }

        public LoanType UpdateLoanType(LoanTypeModel loanTypeModel)
        {
            var loanType = _mapper.Map<LoanType>(loanTypeModel);
            loanType.DateChanged = DateTime.Now;
            _loanTypeRepository.Update(loanType);
            return loanType;
        }
        #endregion
    }
}
