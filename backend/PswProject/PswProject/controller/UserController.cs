using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PswProject.dto;
using PswProject.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService userService;

        public UserController() 
        {
            userService = new UserService();
        }

        //[HttpPost]
        [HttpPost("/registration")]
        // [EnableCors("AllowOrigin")]
        public IActionResult registration([FromBody] RegistrationDTO registrationDTO)
        {
            Console.WriteLine("1234");
            try
            {
                if (userService.registration(registrationDTO))
                {
                    Console.WriteLine("Registration successfull");
                }
            }
            catch (Exception e) {
                Console.WriteLine("Error");
            }
            return Ok(true);
        }
    }
}
