using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using TodoApi.Models;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserDb _context;

    public UsersController(UserDb context)
    {
        _context = context;
    }

    // POST: api/users/login
    [HttpPost]
    [Route("login")]
    public async Task<User>? Login(User user)
    {
        return await UserService.Login(_context, user);
    }

    // GET: api/users
    [HttpGet()]
    [Route("")]
    public async Task<List<User>>? GetUsers(int id)
    {
        return await UserService.GetUsers(_context);
    }

    // GET: api/users/{id}/shows
    [HttpGet()]
    [Route("{id}/shows")]
    public async Task<User>? GetUserShow(int id)
    {
        return await UserService.GetUserShows(_context, id);
    }

    // POST: api/users/{id}/shows
    [HttpPost()]
    [Route("{id}/shows")]
    public async Task<User>? AddUserShow(int id, Show show)
    {
        return await UserService.AddUserShow(_context, id, show);
    }

    // DELETE: api/users/{id}/shows
    [HttpDelete()]
    [Route("{id}/shows/{showId}")]
    public async Task<User>? RemoveUserShow(int id, int showId)
    {
        return await UserService.RemoveUserShow(_context, id, showId);
    }
}
