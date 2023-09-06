using Newtonsoft.Json;

public class Season
{

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("number")]
    public int Number { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("episodeOrder")]
    public int EpisodeOrder { get; set; }

    [JsonProperty("premiereDate")]
    public string PremiereDate { get; set; }

    [JsonProperty("endDate")]
    public string EndDate { get; set; }

}
