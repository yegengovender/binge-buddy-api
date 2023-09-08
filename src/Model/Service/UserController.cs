using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using TodoApi.Models;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserDb _context;

    public UserController(UserDb context)
    {
        _context = context;
    }

    // [HttpGet]
    // [Route("")]
    // public async Task<List<User>>? GetTodoItems()
    // {
    //     return new List<User>();
    // }

    [HttpPost]
    [Route("login")]
    public async Task<User>? Login(User user)
    {
        return await UserService.Login(_context, user);
    }
}
