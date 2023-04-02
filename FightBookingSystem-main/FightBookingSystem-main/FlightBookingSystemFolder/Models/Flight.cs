using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace FlightBookingSystemFolder.Models
{
    public class Flight
    {
        
        [Key]
        [Column("FlightId")]
        public int Flight_Id { get; set; }

        [Column("Flight")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "To is Required")]
        [StringLength(50)]
        public string To { get; set; }
        [Required(ErrorMessage = "From is Required")]
        [StringLength(50)]
        public string From { get; set; }
        [Required(ErrorMessage = "Required to fill")]
        [Display(Name="Planned on")]
        public DateTime DateAndTime { get; set; }
        [Required(ErrorMessage = "Require to Fill")]
        public float Fare { get; set; }
        [Required]
        public int seatAvailable { get; set; }
        //Navigation property
        public virtual ICollection<Booking> Booking { get; set; }
       

    }
      

}
