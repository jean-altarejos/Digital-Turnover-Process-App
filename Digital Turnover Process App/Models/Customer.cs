using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Turnover_Process_App.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string CustomerAccountNumber { get; set; }

        public string LastName { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        public string Category { get; set; }

        [ForeignKey("Id")]
        public int primaryBuyerId { get; set; }

    }
}
