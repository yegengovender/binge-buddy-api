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
    public async Task<List<UserRequest>>? GetUsers()
    {
        return await UserService.GetUsers(_context);
    }

    // GET: api/users/{username}
    [HttpGet()]
    [Route("{username}")]
    public async Task<UserRequest>? GetUsers(string username)
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
    public async Task<UserRequest>? AddUserShow(int id, ShowRequest show)
    {
        return await UserService.AddUserShow(_context, id, show);
    }

    // DELETE: api/users/{id}/shows
    [HttpDelete()]
    [Route("{id}/shows/{showId}")]
    public async Task<UserRequest>? RemoveUserShow(int id, int showId)
    {
        return await UserService.RemoveUserShow(_context, id, showId);
    }

    [HttpPost()]
    [Route("{userId}/watched/{episodeId}")]
    public async Task<UserRequest>? UpdateUser(int userId, int episodeId, bool isWatched)
    {
        return await UserShowsService.WatchedEpisode(_context, userId, episodeId, isWatched);
    }
}
