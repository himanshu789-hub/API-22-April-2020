using System.Collections.Generic;
using AutoMapper;
using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using CarPoolAPI.RepositoryInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CarPoolAPI.Controllers {
    //DONE
    [EnableCors ("AllowMyOrigin")]
    public class UserController : ControllerBase {
        readonly IUserRepository _repos;
        readonly IMapper _mapper;
        public UserController (IUserRepository repos, IMapper mapper) {
            _repos = repos;
            _mapper = mapper;
        }

        [HttpGet]
        public List<UserDTO> GetAll () {
            List<User> Users =  _repos.GetAll ();
            List<UserDTO> ReturnedUsers = _mapper.Map<List<User>,List<UserDTO>>(Users);
            return ReturnedUsers;
        } //DONE

        [HttpPost]
        public UserDTO Create ([FromBody] UserDTO user) {
            User AddedUser = _repos.Create (user);
            UserDTO ReturnUser = _mapper.Map<User,UserDTO>(AddedUser);
            return ReturnUser;
        } //DONE

        [HttpDelete]
        public bool Delete ([FromQuery] int userId) {
            return _repos.Delete (userId);
        }

        [HttpGet]
        public UserDTO GetById ([FromQuery] int id) {
            User RequireUser =  _repos.GetById (id);
            UserDTO ReturedUser = _mapper.Map<User,UserDTO>(RequireUser);
            return ReturedUser;
        } //DONE

        [HttpPut]
        public UserDTO Update ([FromBody] UserDTO user) {
            User UpdatedUser =  _repos.Update (user);
            UserDTO ReturnedUser = _mapper.Map<User,UserDTO>(UpdatedUser);
            return ReturnedUser;
        }

        [HttpGet]
        public UserDTO Login ([FromQuery] string emailId, [FromQuery] string password) {
            User User =  _repos.LogIn (emailId, password);
            UserDTO ReturnedUser = _mapper.Map<User,UserDTO>(User);
            return ReturnedUser;
        } //DONE
    }
}