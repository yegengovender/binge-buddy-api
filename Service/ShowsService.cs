using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

public class ShowsService
{

    internal static async Task<Show?> GetShow(UserDb context, int id)
    {
        return await context.Shows
        .Include(u => u.TvEpisodes)
        .Include(us => us.Seasons)
        .FirstOrDefaultAsync(u => u.Id == id);
    }

    internal static async Task<List<Show>>? GetShows(UserDb context)
    {
        return await context.Shows
        .Include(u => u.TvEpisodes)
        .Include(us => us.Seasons)
        .ToListAsync();        
    }
    
    internal async static Task<Show> AddShow(UserDb context, Show show)
    {
        await context.Shows.AddAsync(show);
        await context.SaveChangesAsync();
        return show;
    }

    internal async static Task<Show> RemoveShow(UserDb context, int id)
    {
        var show = await context.Shows.FirstOrDefaultAsync(us => us.Id == id);
        if (show == null)
        {
            return null;
        }

        context.Shows.Remove(show);
        await context.SaveChangesAsync();

        return show;
    }

    internal async static Task<List<TvEpisode>> GetShowEpisodes(UserDb context, int id)
    {
        var show = await context.Shows
        .Include(s=> s.TvEpisodes)
        .FirstOrDefaultAsync(us => us.Id == id);
        if (show == null)
        {
            return null;
        }

        return show.TvEpisodes.ToList();
    }

    internal async static Task<Show> AddShowEpisodes(UserDb context, int id, IEnumerable<TvEpisodeRequest> episodes)
    {
        var show = await context.Shows.FirstOrDefaultAsync(us => us.Id == id);
        if (show == null)
        {
            return null;
        }

        episodes.ToList().ForEach(async episodeReq => {
            var episode = new TvEpisode(){
                Name = episodeReq.Name,
                SeasonId = episodeReq.Season,
                Number = episodeReq.Number,
                Airdate = episodeReq.Airdate,
                Runtime = episodeReq.Runtime,
                Rating = episodeReq.Rating,
                Image = episodeReq.Image,
                Summary = episodeReq.Summary,
                ShowId = id
            };
            await context.TvEpisodes.AddAsync(episode);            
        });
        
        await context.SaveChangesAsync();

        return show;
    }
}
