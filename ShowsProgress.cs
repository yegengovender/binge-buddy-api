using Newtonsoft.Json;

public class ShowsProgress
{

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("show")]
    public int Show { get; set; }

    [JsonProperty("season")]
    public int Season { get; set; }

    [JsonProperty("episode")]
    public int Episode { get; set; }

    [JsonProperty("updated")]
    public DateTime Updated { get; set; }

}
