using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemFolder.DTO.Registration
{
    public class LogInDto
    {   
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email{get;set;}
        public string Password{get;set;}
        
    }

}