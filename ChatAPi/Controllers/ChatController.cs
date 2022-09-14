using ChatDAL.Data;
using ChatDAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class ChatController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ChatController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult CreateChat(User owner, string name)
        {
            _dbContext.Chats.Add(
                new Chat
                {
                    Name = name,
                    OwnerId = owner.Id
                });
            _dbContext.SaveChanges();
            return Ok();
        }

        [Route("addUser")]
        [HttpPost]
        public IActionResult AddUserToChat(int chatId, User userToAdd)
        {
            var chat = _dbContext.Chats.FirstOrDefault(x => x.Id == chatId);
            if (chat == null)
                return NotFound();

            _dbContext.UserChats.Add(
               new UserChat
               {
                   ChatId = chatId,
                   UserId = userToAdd.Id
               });
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
