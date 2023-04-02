 using Microsoft.AspNetCore.Mvc;
using FlightBookingSystemFolder.Repository;
using FlightBookingSystemFolder.Models;
using FlightBookingSystemFolder.DTO;
using Microsoft.AspNetCore.Authorization;
using FlightBookingSystemFolder.DTO.CheckIn;
using AutoMapper;

[Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
         private readonly IRepositoryBase<CheckIn> interfaceobj = null;
          private readonly IMapper mapper;
       
       public CheckInController(IRepositoryBase<CheckIn> interfaceobj,IMapper mapper)
        {
            this.interfaceobj = interfaceobj;
             this.mapper=mapper;
        }
        [Authorize]
        [HttpPost]
        [Route("CheckIn")]
        public async Task<IActionResult> AddPost(int id)
        {
                var Ch = new CheckIn();
                
                Random s = new Random();
                int num = s.Next(1, 100);
                Ch.Check_Id = num;
                Ch.Booking_id=id;
                Random r = new Random();
                int seat = r.Next(1, 100);
                Ch.Seat_Allocation=seat;
                interfaceobj.InsertModel(Ch);
             
               var result =  interfaceobj.GetModelbyID(id);
            
         
                var DATA=mapper.Map<CheckInDto>(result);
             return Ok(DATA);
             
            
        }
        

    }