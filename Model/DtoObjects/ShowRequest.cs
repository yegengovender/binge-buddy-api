using Newtonsoft.Json;

public record ShowRequest(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("language")] string Language,
    [property: JsonProperty("summary")] string Summary,
    [property: JsonProperty("status")] string Status,
    [property: JsonProperty("premiered")] string Premiered,
    [property: JsonProperty("rating")] float Rating,
    [property: JsonProperty("image")] string Image,
    [property: JsonProperty("imageLarge")] string ImageLarge,
    [property: JsonProperty("episodes")] IEnumerable<TvEpisodeRequest> Episodes,
    [property: JsonProperty("seasons")] IEnumerable<SeasonRequest> Seasons,
    [property: JsonProperty("nextEpisode")] TvEpisodeRequest NextEpisode
);
