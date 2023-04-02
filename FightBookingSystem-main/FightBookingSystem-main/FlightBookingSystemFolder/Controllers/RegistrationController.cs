 using Microsoft.AspNetCore.Mvc;
using FlightBookingSystemFolder.Repository;
using FlightBookingSystemFolder.Models;
using FlightBookingSystemFolder.DTO.Registration;
using System.Data;
using AutoMapper;


    [Route("api/[controller]")]
    [ApiController]//this apicontroller attribute check all the validation which we define in the model classes
    public class RegistrationController : ControllerBase
    {
         private readonly IRepositoryBase<Registration> interfaceobj = null;
         private readonly IMapper mapper;
         private readonly ITokenHandler tokenHandler;
       public RegistrationController(IRepositoryBase<Registration> interfaceobj,IMapper mapper,ITokenHandler tokenHandler)
        {
            this.interfaceobj = interfaceobj;
            this.mapper=mapper;
            this.tokenHandler=tokenHandler;
        }
        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> AddPost([FromBody]RegistrationDto reg)
        {
               var Reg =mapper.Map<Registration>(reg);
               interfaceobj.InsertModel(Reg);
               var user=new LogInDto();
               user.Email=reg.Email;
               user.Password=reg.Password; 
               
             return Ok(await Login(user));
            
        }
        [NonAction]
        public  async Task<Registration>Authenticate(string email,string Password)
        {
            //check if user is authenticate
            var log= interfaceobj.GetModel().FirstOrDefault(x=> x.Email==email&&x.Password==Password);
            return log;

            
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<LogInResDto>>Login([FromBody]LogInDto log)
        { 
            
          try{
              
             var model= await Authenticate(log.Email,log.Password);

            if (model!=null)
            {
              
               return new LogInResDto
                 {
                   Email=model.Email,
                  Token= tokenHandler.CreateTokenAsync(model)
                   };
            }
            else
            return Unauthorized();
          }
           catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
     