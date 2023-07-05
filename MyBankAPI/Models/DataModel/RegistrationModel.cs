using MyBankAPI.Models.Domain;
using System.Text.Json.Serialization;

namespace MyBankAPI.Models.DataModel
{
    public class RegistrationModel : UserModel 
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? IdentityNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
