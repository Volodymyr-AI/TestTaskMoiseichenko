using ChatDAL.Data;
using ChatDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MessageController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("messages")]
        [HttpGet]
        public IEnumerable<Message> GetUsers()
        {
            return _dbContext.Messages.AsEnumerable();
        }

        [HttpPost]
        public string AddMessage(Message message)
        {
            Message newMessage = new()
            {
                Text = message.Text,
                OwnerId = message.OwnerId,
                SenderId = message.SenderId,
                ReceiverId = message.ReceiverId,
                SendTime = DateTime.Now
            };
            _dbContext.Messages.Add(newMessage);
            _dbContext.SaveChanges();
            return newMessage.Text;
        }
    }
}
