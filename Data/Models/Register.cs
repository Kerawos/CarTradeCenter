using System.ComponentModel.DataAnnotations;


namespace CarTradeCenter.Data.Models
{
    public class Register
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdz Hasło")]
        [Compare("Password", ErrorMessage ="Hasła nie zgadzają się ze sobą.")]
        public string PasswordConfirm { get; set; }
    }
}
