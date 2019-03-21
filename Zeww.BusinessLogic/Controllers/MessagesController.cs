using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Zeww.DAL;
using Zeww.Models;
using Zeww.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zeww.BusinessLogic.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public MessagesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: api/messages
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Message Retrieved");
        }

        // GET api/messages/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_unitOfWork.Messages.GetByID(Id).MessageContent);
        }

        [HttpGet("channel/{id}")]
        public IActionResult GetMessageinChannel(int Id)
        {
            return Ok(_unitOfWork.Messages.GetMessagesbyChatId(Id, 5));
        }

        [HttpPost("PostMessage")]
        public IActionResult Post([FromBody] Message message)
        {
            _unitOfWork.Messages.Add(message);
            _unitOfWork.Save();
            return Ok(message);

        }

        [HttpDelete]
        public IActionResult Delete([FromHeader] int id)
        {
            _unitOfWork.Messages.DeleteMessage(id);
            _unitOfWork.Save();
            return Ok("Deleted");
        }

        [HttpPut("EditMessage")]
        public IActionResult EditMessage([FromHeader]int id, [FromHeader]string Messagecontent) {

            Message EditedMessage = _unitOfWork.Messages.GetByID(id);

          if (EditedMessage != null)
            {
                EditedMessage.MessageContent = Messagecontent;
                _unitOfWork.Save();
                return Ok(EditedMessage);
            }
            return NoContent();
        }

        [HttpPut("PinMessage/{messageId}")]
        public IActionResult PinMessage(int messageId)
        {
            _unitOfWork.Messages.PinMessage(messageId);
            _unitOfWork.Save();
            return Ok("Message has been Pinned");
        }
    }
}
