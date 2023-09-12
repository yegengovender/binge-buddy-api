using Microsoft.EntityFrameworkCore;

public partial class ShowsService
{
    internal static async Task<Show?> GetShow(UserDb context, int showId)
    {
        return await context.Shows
            .Include(show => show.TvEpisodes)
            .Include(show => show.Seasons)
            .FirstOrDefaultAsync(show => show.Id == showId);
    }

    internal static async Task<List<Show>>? GetShows(UserDb context)
    {
        return await context.Shows
            .Include(show => show.TvEpisodes)
            .Include(show => show.Seasons)
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

    internal static async Task<List<TvEpisode?>> GetShowEpisodes(UserDb context, int showId)
    {
        var show = await context.Shows
            .Include(show => show.TvEpisodes)
            .FirstOrDefaultAsync(show => show.Id == showId);
        if (show == null)
        {
            return null;
        }

        return show.TvEpisodes.ToList();
    }

    internal static async Task<Show> AddShowEpisodes(
        UserDb context,
        int showId,
        IEnumerable<TvEpisodeRequest> episodes
    )
    {
        var show = await context.Shows.FindAsync(showId);
        if (show == null)
        {
            return null;
        }

        episodes
            .ToList()
            .ForEach(async episodeReq =>
            {
                TvEpisode episode = TransformRequest.ToTvEpisode(showId, episodeReq);
                await context.TvEpisodes.AddAsync(episode);
            });

        await context.SaveChangesAsync();
        return show;
    }

    internal static async Task<List<Season>> GetShowSeasons(UserDb context, int showId)
    {
        var show = await context.Shows
            .Include(s => s.Seasons)
            .FirstOrDefaultAsync(s => s.Id == showId);
        if (show == null)
        {
            return null;
        }

        return show.Seasons.ToList();
    }

    internal static async Task<Show> AddShowSeasons(
        UserDb context,
        int showId,
        IEnumerable<SeasonRequest> seasons
    )
    {
        var show = await context.Shows.FindAsync(showId);
        if (show == null)
        {
            return null;
        }

        seasons
            .ToList()
            .ForEach(async seasonReq =>
            {
                Season season = TransformRequest.ToSeason(showId, seasonReq);
                await context.Seasons.AddAsync(season);
            });

        await context.SaveChangesAsync();
        return show;
    }
}
