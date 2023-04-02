 using Microsoft.AspNetCore.Mvc;
using FlightBookingSystemFolder.Repository;
using FlightBookingSystemFolder.Models;
using FlightBookingSystemFolder.DTO.Booking;
using FlightBookingSystemFolder.Helper;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

[Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
         private readonly IRepositoryBase<Booking> interfaceobj = null;
         private readonly IMapper mapper;
        
          private readonly IRepositoryBase<Flight> interfaceobjF = null;
          
         
       public BookingController(IRepositoryBase<Booking> interfaceobj, IMapper mapper,IRepositoryBase<Flight> interfaceobjF)
        {
            this.interfaceobj = interfaceobj;
            this.mapper=mapper;
           this.interfaceobjF=interfaceobjF;
        }
       [Authorize]
        [HttpPost]
        [Route("Booking")]
        public async Task<IActionResult> AddBooking(int Id,[FromBody]BookingDto book)
        {   
                var BOOK=mapper.Map<Booking>(book);
                 Random s = new Random();
                 BOOK.ReferenceNo=s.Next(1,100);
                 BOOK.FlightId=Id;
                 interfaceobj.InsertModel(BOOK);
                 return Ok( BOOK.ReferenceNo);
           
            
        }
       [Authorize]
        [HttpGet]
        [Route("Booking_Information")]
        public async Task<IActionResult> GetAllData()
        {
            try{
            var result =  interfaceobj.GetModel();

            return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetBookingDetails")]
        public async Task<IActionResult> GetAllData(int id)
        { 
            try
            {
                  var result = (from model in interfaceobj.GetModel()
                  join fmodel in interfaceobjF.GetModel()
                  on model.FlightId equals fmodel.Flight_Id
                  where model.ReferenceNo == id
                  select new { Model = model, FModel = fmodel }).FirstOrDefault();

                 if (result != null)
                  {
                    var FlightAndBooking = new BookingAndFlightDto
                    {
                      Passenger_Name = result.Model.Passenger_Name,
                      PhoneNumber = result.Model.PhoneNumber,
                      DateAndTime=result.FModel.DateAndTime,
                      Name = result.FModel.Name,
                      To = result.FModel.To,
                      From = result.FModel.From,
                      Fare = result.FModel.Fare,
                      FlightId=result.Model.FlightId,
                      Booking_id =result.Model.Booking_id
                     };
                    

                    // Return the newly created DTO object
                    return Ok(FlightAndBooking);
                  }

                   else
                     // Return a 404 Not Found response if no data is found
                     return NotFound();
                   
            }
               catch(Exception ex)
             {
            return Ok(ex.Message);
             }
        }
    }

    

    