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
    public class MessageController : ControllerBase
    {
        // GET: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpGet(Name = "GetMessages")]
        public List<Message> Get()
        {
            IGetAllMessages readMessages = new ReadMessageData();
            return readMessages.GetMessages();
        }
        // GET: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetMessage")]
        public Message Get(int id)
        {
            IGetMessage readMessage = new ReadMessageData();
            return readMessage.GetMessage(id);
        }

        // POST: api/attendance
        [EnableCors("AnotherPolicy")]
        [HttpPost(Name = "PostMessage")]
        public void Post(Message m)
        {
            IAddMessage add = new AddMessage();
            add.Add(m);
        }

        // PUT: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Message m)
        {
            IEditMessage edit = new EditMessage();
            edit.Edit(m);
        }

        // DELETE: api/attendance/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteMessage delete = new DeleteMessage();
            delete.Delete(id);
        }
    }
}