using MyBankAPI.Models.Domain;

namespace MyBankAPI.Models.DataModel
{
    public class LoanApplicationModel : BaseModel
    {
        public int LoanTypeID { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; }=DateTime.Now;
        public DateTime EndDate { get; set; }
        public int LoanStatusId { get; set; }   
        public Guid UserId { get; set; }
        public int CurrencyId { get; set; }
    }
}
