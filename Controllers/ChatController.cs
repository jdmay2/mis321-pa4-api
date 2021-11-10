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
    public class ChatController : ControllerBase
    {
        // GET: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetChats")]
        public List<Chat> Get()
        {
            IGetAllChats readChats = new ReadChatData();
            return readChats.GetChats();
        }
        // GET: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetChat")]
        public Chat Get(int id)
        {
            IGetChat readChat = new ReadChatData();
            return readChat.GetChat(id);
        }

        // POST: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostChat")]
        public void Post(Chat c)
        {
            IAddChat add = new AddChat();
            add.Add(c);
        }

        // PUT: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Chat c)
        {
            IEditChat edit = new EditChat();
            edit.Edit(c);
        }

        // DELETE: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteChat delete = new DeleteChat();
            delete.Delete(id);
        }
    }
}