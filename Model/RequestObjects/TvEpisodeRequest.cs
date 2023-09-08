
using Newtonsoft.Json;

public class TvEpisodeRequest {
    
    [JsonProperty("id")]
    public int Id;
    
    [JsonProperty("name")]
    public string Name;
    
    [JsonProperty("season")]
    public int Season;
    
    [JsonProperty("number")]
    public int Number;
    
    [JsonProperty("airdate")]
    public string Airdate;
    
    [JsonProperty("runtime")]
    public int Runtime;
    
    [JsonProperty("rating")]
    public int Rating;
    
    [JsonProperty("image")]
    public string Image;
    
    [JsonProperty("summary")]
    public string Summary;
    
    [JsonProperty("showId")]
    public int ShowId;
    
    [JsonProperty("watchedDate")]
    public DateTime WatchedDate;
    
}
    