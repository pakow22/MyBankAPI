using AutoMapper;
using MyBankAPI.Models.DataModel;
using MyBankAPI.Models.Domain;

namespace MyBankAPI.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<LoanApplicationModel, LoanApplication>().ReverseMap();
            CreateMap<CurrencyModel, Currency>().ReverseMap();
            CreateMap<LoanStatusModel, LoanStatus>().ReverseMap();
            CreateMap<LoanTypeModel, LoanType>().ReverseMap();
        }

    }
}
