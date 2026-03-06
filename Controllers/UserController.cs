using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogapi.Models;
using blogapi.Models.DTO;
using blogapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }
        //Functions to add our user type of createAccount call User Todadd this will return bool once our user is addded
        // Add User 
        [HttpPost("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }
        //GetAllUsers
        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _data.GetAllUsers();


        }
        // GetUserByUserName
        [HttpGet("GetUserByUsername")]
        public UserIdDTO GetUserDTOUserName(string username)
        {
            return _data.GetUserIdDTOByUserName(username);
        }



        //Login Endpoint
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }



        //Delete User
        [HttpPost("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

        //UpdateUser
        public bool UpdateUesr(int id, string username)
        {
            return _data.UpdateUser(id,username);
        }

    }
}