using Newtonsoft.Json;

public record ShowRequest(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("language")] string Language,
    [property: JsonProperty("summary")] string Summary,
    [property: JsonProperty("status")] string Status,
    [property: JsonProperty("premiered")] string Premiered,
    [property: JsonProperty("rating")] int Rating,
    [property: JsonProperty("image")] string Image,
    [property: JsonProperty("imageLarge")] string ImageLarge,
    [property: JsonProperty("episodes")] IEnumerable<TvEpisode> Episodes,
    [property: JsonProperty("seasons")] IEnumerable<Season> Seasons,
    [property: JsonProperty("nextEpisode")] TvEpisode NextEpisode
);
