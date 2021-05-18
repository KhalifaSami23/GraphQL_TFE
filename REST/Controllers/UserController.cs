using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;
using TFE_Khalifa_Sami_2021.REST.Repositories;

namespace TFE_Khalifa_Sami_2021.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userRepository.GetUsers());
        }
        
        [HttpGet("getById/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetUserById(id));
        }
        
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _userRepository.PostUser(user);
            return Ok(user);
        }
        
        [HttpPut]
        public ActionResult UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            return Ok(user);
        }
        
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
           _userRepository.DeleteUser(id);
            return Ok($"{id} Removed ! ");
        }
        
    }
}