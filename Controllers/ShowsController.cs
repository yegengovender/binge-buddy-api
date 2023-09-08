using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ShowsController : ControllerBase
{
    private readonly UserDb _context;

    public ShowsController(UserDb context)
    {
        _context = context;
    }

    // GET: api/shows
    [HttpGet()]
    [Route("")]
    public async Task<List<Show>>? GetShows(int id)
    {
        return await ShowsService.GetShows(_context);
    }

    // GET: api/shows/{id}
    [HttpGet()]
    [Route("{id}")]
    public async Task<Show>? GetShow(int id)
    {
        return await ShowsService.GetShow(_context, id);
    }

    // POST: api/shows/{id}
    [HttpPost()]
    [Route("{id}")]
    public async Task<Show>? AddShow(Show show)
    {
        return await ShowsService.AddShow(_context, show);
    }

    // DELETE: api/shows/{id}
    [HttpDelete()]
    [Route("{id}")]
    public async Task<Show>? RemoveShow(int id)
    {
        return await ShowsService.RemoveShow(_context, id);
    }

    // GET: api/shows/{id}/episodes
    [HttpGet()]
    [Route("{id}/episodes")]
    public async Task<List<TvEpisode>> GetShowEpisodes(int id)
    {
        return await ShowsService.GetShowEpisodes(_context, id);
    }

    // POST: api/shows/{id}/episodes
    [HttpPost()]
    [Route("{id}/episodes")]
    public async Task<Show> AddShowEpisodes(int id, IEnumerable<TvEpisode> episodes)
    {
        return await ShowsService.AddShowEpisodes(_context, id, episodes);
    }

}
