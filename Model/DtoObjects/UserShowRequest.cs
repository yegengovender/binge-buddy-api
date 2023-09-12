using Newtonsoft.Json;

public record UserShowRequest(
    [property: JsonProperty("showId")] int ShowId,
    [property: JsonProperty("episodeIds")] IEnumerable<int> EpisodeIds,
    [property: JsonProperty("lastEpisode")] int? LastEpisode
);
