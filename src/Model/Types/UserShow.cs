using Newtonsoft.Json;

public class UserShow
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("showId")]
    public int ShowId { get; set; }

    [JsonProperty("lastEpisode")]
    public int LastEpisode { get; set; }

    [JsonProperty("progress")]
    public IEnumerable<ShowsProgress>? Progress { get; set; }
}
