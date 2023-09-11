using System.ComponentModel.DataAnnotations.Schema;

public class UserShowActivity
{
    public int Id { get; set; }

    [ForeignKey("UserShowId")]
    public UserShow UserShow { get; set; }

    [ForeignKey("TvEpisodeId")]
    public TvEpisode Episode { get; set; }
    public DateTime Updated { get; set; }
}