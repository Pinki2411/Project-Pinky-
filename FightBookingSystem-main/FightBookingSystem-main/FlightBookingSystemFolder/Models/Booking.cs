using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemFolder.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Booking_id { get; set; }
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
        public string Passport_No { get; set; }
         [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required]

        [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "PhoneNumber Must be 10 Digit Only")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Age must be between 1-100 only")]
        public int Age { get; set; }
        [Required]
        public int ReferenceNo { get; set; }
        [Required]
         public int FlightId { get; set; }

        //Navigation Property

        public virtual Flight Flight { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public virtual Registration Registration { get; set; }

        public virtual CheckIn CheckIn { get; set; }
    }
}
