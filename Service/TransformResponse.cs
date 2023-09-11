public partial class ShowsService
{
    internal class TransformResponse
    {
        internal static UserRequest ToUser(User user, List<UserShow> userShows)
        {
            return new(
                user.Id,
                user.Name,
                user.Email,
                user.LoggedIn,
                userShows
                    .Select(
                        us =>
                            ToShowObject(
                                us.Show,
                                us.Show.TvEpisodes.ToList(),
                                us.Show.Seasons.ToList()
                            )
                    )
                    .ToList(),
                userShows.Select(us => ToUserShow(us)).ToList()
            );
        }

        internal static UserShowRequest ToUserShow(UserShow userShow)
        {
            return new(
                userShow.Show.WebId,
                userShow.UserShowActivities
                    .Select(u => u.Episode.WebId)
                    .ToList(),
                null
            );
        }

        internal static ShowRequest ToShowObject(
            Show show,
            List<TvEpisode> episodes,
            List<Season> seasons
        )
        {
            return new(
                show.WebId,
                show.Name,
                show.Language,
                show.Summary,
                show.Status,
                show.Premiered,
                show.Rating,
                show.Image,
                show.ImageLarge,
                episodes.Select(e => ToTvEpisode(show.Id, e)).ToList(),
                seasons.Select(s => ToSeason(show.Id, s)).ToList(),
                ToTvEpisode(show.Id, show.NextEpisode)
            );
        }

        internal static TvEpisodeRequest? ToTvEpisode(int showId, TvEpisode? episode)
        {
            if (episode == null)
            {
                return null;
            }
            return new(
                episode.WebId,
                episode.Name,
                episode.SeasonId,
                episode.Number,
                episode.Airdate,
                episode.Runtime,
                episode.Rating,
                episode.Image,
                episode.Summary,
                showId
            );
        }

        internal static SeasonRequest ToSeason(int showId, Season season)
        {
            return new(
                season.WebId,
                season.Number,
                season.Name,
                season.EpisodeOrder,
                season.PremiereDate,
                season.EndDate,
                showId
            );
        }
    }
}
