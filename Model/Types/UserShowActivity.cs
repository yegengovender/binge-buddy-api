using System.ComponentModel.DataAnnotations.Schema;

public class UserShowActivity
{
    public int Id { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("TvEpisodeId")]
    public TvEpisode Episode { get; set; }
    public DateTime Updated { get; set; }
}