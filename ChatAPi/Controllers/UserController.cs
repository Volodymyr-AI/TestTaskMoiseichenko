using ChatDAL.Data;
using ChatDAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("users")]
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.AsEnumerable();
        }

        //[Route("user/{id}")]
        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        //Delete User
        [HttpDelete]
        public string DeleteUserById(int id)
        {
            User user = _dbContext.Users.Where(x => x.Id == id).Single<User>();
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return "Record has successfully Deleted";
        }

        [HttpPost]
        public string AddUser(User user)
        {
            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.Email = user.Email;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return "New user is added";

        }
        
    }
}
