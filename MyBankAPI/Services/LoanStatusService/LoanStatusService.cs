using AutoMapper;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Repositories.CuurencyRepository;
using MyBankAPI.Repositories.LoanStatusRepository;

namespace MyBankAPI.Services.LoanStatusService
{
    public class LoanStatusService : ILoanStatusService
    {
        #region private fields
        private readonly IMapper _mapper;
        private readonly ILoanStatusRepository _loanStatusRepository;
        #endregion

        #region ctor
        public LoanStatusService(ILoanStatusRepository loanStatusRepository,IMapper mapper)
        {
            _loanStatusRepository = loanStatusRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods
        public LoanStatus AddLoanStatus(LoanStatusModel loanStatusModel)
        {
            LoanStatus loanStatus = new()
            {
                Name = loanStatusModel.Name,
                DateCreated = DateTime.Now,
            };
            _loanStatusRepository.Add(loanStatus);
            return loanStatus;
        }
        public IEnumerable<LoanStatus> DeleteLoanstatus(int id)
        {
            var loanStatus = _loanStatusRepository.GetById(id);
            loanStatus.DateDeleted = DateTime.Now;
            _loanStatusRepository.Delete(loanStatus);
            return _loanStatusRepository.GetAll();
        }

        public List<LoanStatus> GetAllLoanStatuses()
        {
            var loanSatuses = _loanStatusRepository.GetAll().Where(x => x.DateDeleted == null); ;
            return loanSatuses.ToList();
        }

        public LoanStatus GetLoanStatusById(int id)
        {
            return _loanStatusRepository.GetById(id);
        }

        public LoanStatus UpdateLoanStatus(int id, LoanStatusModel loanStatusModel)
        {
            var status = _loanStatusRepository.GetById(id);

            status.DateChanged = DateTime.Now;
            status.Name = loanStatusModel.Name;
            _loanStatusRepository.Update(status);
            return status;
        }
        #endregion
    }
}
