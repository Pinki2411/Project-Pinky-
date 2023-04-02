using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemFolder.DTO.Booking
{
    public class BookingDto
    {
         [Required]
        [StringLength(30)]
        public string Passenger_Name { get; set; }
         [Required]
        [StringLength(40)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
         public string Country { get; set; }

         [Required]
        [StringLength(8, ErrorMessage = "PassPost Number Must be 8 characters Only")]
        //[RegularExpression(@"^[A-Z]{1}-[0-9]{7}$", ErrorMessage = "PassPost is not valid")]
         public string Passport_No { get; set; }

          [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "PhoneNumber Must be 10 Digit Only")]
          [StringLength(10)]
          public string PhoneNumber { get; set; }

         [Required]
         [StringLength(10)]
         public string Gender { get; set; }

         [Required]
         public int Age { get; set; }

         [Required(ErrorMessage = "Email is Required")]
         [DataType(DataType.EmailAddress)]
         public string Email { get; set; }
          public int ReferenceNo { get; set; }
    }
}