namespace MyBankAPI.Models.Domain
{
    public class LoanApplication : BaseModel
    {
        public Currency? Currency { get; set; }
        public int CurrencyId { get; set; }
        public LoanType? LoanType { get; set; }
        public int LoanTypeId { get; set; }
        public float Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LoanStatus? LoanStatus { get; set; }
        public int LoanStatusId { get; set; }
        public User? User { get; set; }
        public Guid? UserId { get; set; }
        

    }
}
