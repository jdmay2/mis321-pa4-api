using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using mis321_pa4_api.Model;
using mis321_pa4_api.Interfaces;

namespace mis321_pa4_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetUsers")]
        public List<User> Get()
        {
            IGetAllUsers readUsers = new ReadUserData();
            return readUsers.GetUsers();
        }
        // GET: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetUser")]
        public User Get(int id)
        {
            IGetUser readUser = new ReadUserData();
            return readUser.GetUser(id);
        }

        // POST: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostUser")]
        public void Post(User u)
        {
            IAddUser add = new AddUser();
            add.Add(u);
        }

        // PUT: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] User u)
        {
            IEditUser edit = new EditUser();
            edit.Edit(u);
        }

        // DELETE: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteAllLikes dl = new DeleteUserLikes();
            dl.DeleteLikes(id);
            IDeleteAllPosts dsp = new DeleteSubUserPosts();
            dsp.DeletePosts(id);
            IDeleteAllPosts dp = new DeleteUserPosts();
            dp.DeletePosts(id);
            IDeleteUser delete = new DeleteUser();
            delete.Delete(id);
        }
    }
}