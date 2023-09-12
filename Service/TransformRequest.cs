public partial class ShowsService
{
    internal class TransformRequest
    {
        internal static Show ToShowObject(ShowRequest showRequest)
        {
            var show = new Show()
            {
                WebId = showRequest.Id,
                Name = showRequest.Name,
                Language = showRequest.Language,
                Summary = showRequest.Summary,
                Status = showRequest.Status,
                Premiered = showRequest.Premiered,
                Rating = showRequest.Rating,
                Image = showRequest.Image,
                ImageLarge = showRequest.ImageLarge,
                NextEpisode = ToTvEpisode(showRequest.Id, showRequest.NextEpisode)
            };

            return show;
        }

        internal static TvEpisode? ToTvEpisode(int showId, TvEpisodeRequest? episodeReq)
        {
            if (episodeReq == null)
            {
                return null;
            }
            return new TvEpisode()
            {
                WebId = episodeReq.Id,
                Name = episodeReq.Name,
                SeasonId = episodeReq.Season,
                Number = episodeReq.Number,
                Airdate = episodeReq.Airdate,
                Runtime = episodeReq.Runtime,
                Rating = episodeReq.Rating,
                Image = episodeReq.Image,
                Summary = episodeReq.Summary,
                ShowId = showId
            };
        }

        internal static Season ToSeason(int id, SeasonRequest seasonReq)
        {
            return new Season()
            {
                WebId = seasonReq.Id,
                Name = seasonReq.Name,
                Number = seasonReq.Number,
                EpisodeOrder = seasonReq.EpisodeOrder,
                PremiereDate = seasonReq.PremiereDate,
                EndDate = seasonReq.EndDate,
                ShowId = id
            };
        }
    }
}
