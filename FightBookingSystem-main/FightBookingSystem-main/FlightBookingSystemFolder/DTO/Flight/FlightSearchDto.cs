using System.ComponentModel.DataAnnotations;

namespace FlightBookingSystemFolder.DTO.Flight
{
    public class FlightSearchDto
    {
        
        public string To {get;set;}
        
        public string From {get;set;}

      
        public DateTime DateAndTime{get;set;}
         public float Fare { get; set; }
         public string Name{get; set;}
          public int Flight_Id { get; set; }
    }

}