using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using TodoApi.Models;


[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly UserDb _context;

    public TodoItemsController(UserDb context)
    {
        _context = context;
    }

    // GET: api/TodoItems
    [HttpGet]
    public async Task<List<TvEpisode>>? GetTodoItems()
    {
        var episodes = await _context.TvEpisodes.Include(e => e.Show).ToListAsync();
        return episodes;
    }
}
