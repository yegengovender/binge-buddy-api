using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

public partial class ShowsService
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

    internal static async Task<Show> AddShow(UserDb context, ShowRequest showRequest)
    {
        Show show = TransformRequest.ToShowObject(showRequest);
        await context.Shows.AddAsync(show);

        await context.SaveChangesAsync();
        return show;
    }

    internal static async Task<Show> RemoveShow(UserDb context, int id)
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

    internal static async Task<List<TvEpisode>> GetShowEpisodes(UserDb context, int id)
    {
        var show = await context.Shows
            .Include(s => s.TvEpisodes)
            .FirstOrDefaultAsync(s => s.Id == id);
        if (show == null)
        {
            return null;
        }

        return show.TvEpisodes.ToList();
    }

    internal static async Task<Show> AddShowEpisodes(
        UserDb context,
        int id,
        IEnumerable<TvEpisodeRequest> episodes
    )
    {
        var show = await context.Shows.FindAsync(id);
        if (show == null)
        {
            return null;
        }

        episodes
            .ToList()
            .ForEach(async episodeReq =>
            {
                TvEpisode episode = TransformRequest.ToTvEpisode(id, episodeReq);
                await context.TvEpisodes.AddAsync(episode);
            });

        await context.SaveChangesAsync();
        return show;
    }

    internal static async Task<List<Season>> GetShowSeasons(UserDb context, int id)
    {
        var show = await context.Shows.Include(s => s.Seasons).FirstOrDefaultAsync(s => s.Id == id);
        if (show == null)
        {
            return null;
        }

        return show.Seasons.ToList();
    }

    internal static async Task<Show> AddShowSeasons(
        UserDb context,
        int id,
        IEnumerable<SeasonRequest> seasons
    )
    {
        var show = await context.Shows.FindAsync(id);
        if (show == null)
        {
            return null;
        }

        seasons
            .ToList()
            .ForEach(async seasonReq =>
            {
                Season season = TransformRequest.ToSeason(id, seasonReq);
                await context.Seasons.AddAsync(season);
            });

        await context.SaveChangesAsync();
        return show;
    }
}
