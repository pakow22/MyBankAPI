using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyBankAPI.Models.Domain
{
    public class BaseModel
    {
        [JsonIgnore]
        [Key]
        public int ID { get; set; } 
        [JsonIgnore]
        public DateTime? DateCreated { get; set; }
        [JsonIgnore]
        public DateTime? DateChanged { get; set; }
        [JsonIgnore]
        public DateTime? DateDeleted { get; set; }

    }
}
