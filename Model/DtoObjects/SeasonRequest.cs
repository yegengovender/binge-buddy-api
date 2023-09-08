using Newtonsoft.Json;

public record SeasonRequest(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("url")] string Url,
    [property: JsonProperty("number")] int Number,
    [property: JsonProperty("name")] string Name,
    [property: JsonProperty("episodeOrder")] int EpisodeOrder,
    [property: JsonProperty("premiereDate")] string PremiereDate,
    [property: JsonProperty("endDate")] string EndDate
);
