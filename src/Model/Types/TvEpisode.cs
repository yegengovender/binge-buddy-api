using Newtonsoft.Json;

public class TvEpisode
{

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("season")]
    public int Season { get; set; }

    [JsonProperty("number")]
    public int Number { get; set; }

    [JsonProperty("airdate")]
    public string? Airdate { get; set; }

    [JsonProperty("runtime")]
    public int Runtime { get; set; }

    [JsonProperty("rating")]
    public int Rating { get; set; }

    [JsonProperty("image")]
    public string? Image { get; set; }

    [JsonProperty("summary")]
    public string? Summary { get; set; }

    [JsonProperty("watchedDate")]
    public DateTime? WatchedDate { get; set; }

}
