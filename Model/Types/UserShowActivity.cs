using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

public class UserShowActivity
{
    public int Id { get; set; }

    [ForeignKey("UserShowId")]
    [JsonIgnore]
    public UserShow UserShow { get; set; }

    [ForeignKey("TvEpisodeId")]
    public TvEpisode Episode { get; set; }
    public DateTime Updated { get; set; }
}