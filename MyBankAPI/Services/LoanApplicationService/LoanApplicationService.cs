using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;
using MyBankAPI.Repository.LoanApplicationRepository;
using MyBankAPI.Services.CuurencyService;
using MyBankAPI.Services.LoanStatusService;
using MyBankAPI.Services.LoanTypeService;
using System;

namespace MyBankAPI.Services.LoanApplicationService
{
    public class LoanApplicationService : ILoanApplicationService
    {
        #region private fields
        private readonly IMapper _mapper;
        private readonly ILoanApplicationRepository _loanApplicationRepository;
        #endregion

        #region ctor
        public LoanApplicationService(IMapper mapper,ILoanApplicationRepository loanApplicationRepository)
        {
            _loanApplicationRepository = loanApplicationRepository;
            _mapper = mapper;
        }
        #endregion

        #region methods
        public LoanApplicationModel AddLoanApplication(LoanApplicationModel application)
        {
            LoanApplication loanApplication = new()
            {
                Amount = application.Amount,
                LoanStatusId = application.LoanStatusId,
                UserId = application.UserId,
                CurrencyId = application.CurrencyId,
                LoanTypeId = application.LoanTypeID,
                DateCreated = DateTime.Now,
                StartDate = application.StartDate,
                EndDate = application.EndDate,
            };
            _loanApplicationRepository.Add(loanApplication);
            return application;
        }

        public IEnumerable<LoanApplicationModel> DeleteLoanApplication(int id)
        {
            var loanApplication = _loanApplicationRepository.GetById(id);
            if (loanApplication != null)
            {
                loanApplication.DateDeleted = DateTime.Now;
                _loanApplicationRepository.Delete(loanApplication);
            }
            var loanApplications = _loanApplicationRepository.GetAll().Where(x=>x.DateDeleted == null);
            var mappedModel = _mapper.Map<List<LoanApplicationModel>>(loanApplications);
            return mappedModel;
        }

        public LoanApplicationModel GetLoanApplicationById(int id)
        {
           var loanApplication = _loanApplicationRepository.GetById(id);
           return _mapper.Map<LoanApplicationModel>(loanApplication);
        }
       
        public List<LoanApplicationModel> GetLoanApplications()
        {
          var applications = _loanApplicationRepository.GetAll();
          return _mapper.Map<List<LoanApplicationModel>>(applications);
        }
        public LoanApplicationModel UpdateLoanApplication(int id,LoanApplicationModel applicationModel)
        {
            var loanapplication = GetLoanById(id);
            loanapplication.LoanStatusId = applicationModel.LoanStatusId;
            loanapplication.CurrencyId = applicationModel.CurrencyId;
            loanapplication.StartDate = applicationModel.StartDate;
            loanapplication.EndDate = applicationModel.EndDate;
            loanapplication.Amount = applicationModel.Amount;
            loanapplication.DateChanged = DateTime.Now;
            loanapplication.UserId = applicationModel.UserId;

            _loanApplicationRepository.Update(loanapplication);
            return default;
        }
        #endregion

        #region private methods 
        private LoanApplication GetLoanById(int id)
        {
            var loanApplication = _loanApplicationRepository.GetById(id);
            return loanApplication;
        }
        #endregion
    }
}
