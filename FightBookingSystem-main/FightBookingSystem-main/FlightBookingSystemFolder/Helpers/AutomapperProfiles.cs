using AutoMapper;
using FlightBookingSystemFolder.DTO.Booking;
using FlightBookingSystemFolder.DTO.CheckIn;
using FlightBookingSystemFolder.DTO.Flight;
using FlightBookingSystemFolder.DTO.Registration;
using FlightBookingSystemFolder.Models;

namespace FlightBookingSystemFolder.Helper;
public class AutomapperProfiles:Profile
{
  public AutomapperProfiles()
  {
    CreateMap<Booking,BookingDto>().ReverseMap();
    CreateMap<Registration,RegistrationDto>().ReverseMap();
    CreateMap<Registration,LogInDto>().ReverseMap();
     CreateMap<Flight,FlightSearchDto>().ReverseMap();
      CreateMap<CheckIn,CheckInDto>().ReverseMap();
  }
}