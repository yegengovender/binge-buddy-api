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
                ImageLarge = showRequest.ImageLarge
            };

            return show;
        }

        internal static TvEpisode ToTvEpisode(int id, TvEpisodeRequest episodeReq)
        {
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
                ShowId = id
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
