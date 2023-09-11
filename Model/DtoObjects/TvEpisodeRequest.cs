using Newtonsoft.Json;

public record TvEpisodeRequest(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("season")] int Season,
    [property: JsonProperty("number")] int Number,
    [property: JsonProperty("airdate")] string Airdate,
    [property: JsonProperty("runtime")] int Runtime,
    [property: JsonProperty("rating")] float Rating,
    [property: JsonProperty("image")] string Image,
    [property: JsonProperty("summary")] string Summary,
    [property: JsonProperty("showId")] int ShowId,
    [property: JsonProperty("watchedDate")] DateTime? WatchedDate
);
