using Newtonsoft.Json;

public class Show
{

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("language")]
    public string? Language { get; set; }

    [JsonProperty("summary")]
    public string? Summary { get; set; }

    [JsonProperty("status")]
    public string? Status { get; set; }

    [JsonProperty("premiered")]
    public string? Premiered { get; set; }

    [JsonProperty("rating")]
    public int Rating { get; set; }

    [JsonProperty("image")]
    public string? Image { get; set; }

    [JsonProperty("imageLarge")]
    public string? ImageLarge { get; set; }

    [JsonProperty("episodes")]
    public IEnumerable<TvEpisode> Episodes { get; set; }

    [JsonProperty("seasons")]
    public IEnumerable<Season> Seasons { get; set; }

    [JsonProperty("nextEpisode")]
    public TvEpisode? NextEpisode { get; set; }

}
