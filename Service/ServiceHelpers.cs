using Microsoft.EntityFrameworkCore;

public class ServiceHelpers
{
    internal static IQueryable<User> GetDbUsers(UserDb context)
    {
        return context.Users
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .ThenInclude(s => s.TvEpisodes)
            .Include(u => u.UserShows)
            .ThenInclude(us => us.Show)
            .ThenInclude(s => s.Seasons)
            .Include(u => u.UserShows)
            .ThenInclude(us => us.UserShowActivities);
    }

    internal static Show StoreEpisodesAndSeasons(UserDb context, ShowRequest showRequest)
    {
        Show show = ShowsService.TransformRequest.ToShowObject(showRequest);

        // Store Episodes
        List<TvEpisode?> tvEpisodes = showRequest.Episodes
            .Select(e => ShowsService.TransformRequest.ToTvEpisode(show.Id, e))
            .ToList();
        tvEpisodes.ForEach(async e =>
        {
            if (!await context.TvEpisodes.AnyAsync(episode => episode.WebId == e.Id))
            {
                await context.TvEpisodes.AddAsync(e);
            }
        });
        show.TvEpisodes = tvEpisodes;

        // Store Seasons
        List<Season> seasons = showRequest.Seasons
            .Select(s => ShowsService.TransformRequest.ToSeason(show.Id, s))
            .ToList();
        seasons.ForEach(async s =>
        {
            if (!await context.Seasons.AnyAsync(season => season.WebId == s.Id))
            {
                await context.Seasons.AddAsync(s);
            }
        });
        show.Seasons = seasons;

        // Store Next Episode
        show.NextEpisode = ShowsService.TransformRequest.ToTvEpisode(
            show.Id,
            showRequest.NextEpisode
        );
        return show;
    }
}
