using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemFolder.DTO.Registration
{
    public class RegistrationDto
    {
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email{get;set;}

        [Required]
        [StringLength(40)]
        public string FullName{get;set;}

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string Password{get;set;}
        
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}