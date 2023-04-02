namespace FlightBookingSystemFolder.DTO.Booking
{
      public class BookingAndFlightDto
      {
        public string Passenger_Name { get; set; }
         public string PhoneNumber { get; set; }
          public string To {get;set;}
          public string From {get;set;}
          public string Name{get; set;}
          public DateTime DateAndTime{get;set;}
          public float Fare { get; set; }
           public int FlightId { get; set; }
          public int Booking_id { get; set; }
      }
}