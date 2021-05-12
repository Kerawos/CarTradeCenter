
using System.ComponentModel.DataAnnotations;


namespace CarTradeCenter.Data.Models {
    public class User 
    {
        public string Id { get; set;}
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public double Amount { get; set; }
    }
}
