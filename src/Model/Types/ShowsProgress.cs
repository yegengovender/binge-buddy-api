using Newtonsoft.Json;

public class ShowsProgress
{

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("show")]
    public int ShowId { get; set; }

    [JsonProperty("season")]
    public int SeasonId { get; set; }

    [JsonProperty("episode")]
    public int EpisodeId { get; set; }

    [JsonProperty("updated")]
    public DateTime Updated { get; set; }

}
