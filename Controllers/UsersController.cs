using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserDb _context;

    public UsersController(UserDb context)
    {
        _context = context;
    }

    // GET: api/users
    [HttpGet()]
    [Route("")]
    public async Task<List<User>>? GetUsers()
    {
        return await UserService.GetUsers(_context);
    }

    // GET: api/users/{username}
    [HttpGet()]
    [Route("{username}")]
    public async Task<User>? GetUsers(string username)
    {
        return await UserService.GetUserByName(_context, username);
    }

    // GET: api/users/{id}/shows
    [HttpGet()]
    [Route("{id}/shows")]
    public async Task<List<ShowRequest>>? GetUserShow(int id)
    {
        return await UserService.GetUserShows(_context, id);
    }

    // POST: api/users/{id}/shows
    [HttpPost()]
    [Route("{id}/shows")]
    public async Task<User>? AddUserShow(int id, ShowRequest show)
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
