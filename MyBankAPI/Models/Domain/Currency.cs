using System.ComponentModel.DataAnnotations;

namespace MyBankAPI.Models.Domain
{
    public class Currency : BaseModel
    {
        public string? Name { get; set; }
    }
}
