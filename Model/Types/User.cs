using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public bool LoggedIn { get; set; }
    public IEnumerable<UserShow> UserShows { get; set; } = new List<UserShow>();
}

public class UserShow
{
    public int Id { get; set; }

    [ForeignKey("UserId")]
    [JsonIgnore]
    public User User { get; set; }

    [ForeignKey("ShowId")]
    public Show Show { get; set; }
}

public class Show
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Language { get; set; } = "";
    public string Summary { get; set; } = "";
    public string Status { get; set; } = "";
    public string Premiered { get; set; } = "";
    public float Rating { get; set; }
    public string Image { get; set; } = "";
    public string ImageLarge { get; set; } = "";
    [NotMapped]
    public TvEpisode? NextEpisode { get; set; }
    public IEnumerable<TvEpisode> TvEpisodes { get; set; }
    public IEnumerable<Season> Seasons { get; set; }
}

public class Season
{
    public int Id { get; set; }
    public string Url { get; set; } = ""; // : string;
    public int Number { get; set; }
    public string Name { get; set; } = ""; // : string;
    public int EpisodeOrder { get; set; }
    public string PremiereDate { get; set; } = ""; // : string;
    public string EndDate { get; set; } = ""; // : string;
    public int ShowId { get; set; }
    [ForeignKey("ShowId")]
    [JsonIgnore]
    public Show Show { get; set; }
}

public class TvEpisode
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int SeasonId { get; set; }
    public int Number { get; set; }
    public string Airdate { get; set; } = "";
    public float Runtime { get; set; }
    public float Rating { get; set; }
    public string Image { get; set; } = "";
    public string Summary { get; set; } = "";
    public int ShowId { get; set; }
    [ForeignKey("ShowId")]
    [JsonIgnore]
    public Show Show { get; set; }

    [JsonIgnore]
    public string WatchedDate { get; set; } = "";
}

public class UserShowActivity
{
    public int Id { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("TvEpisodeId")]
    public TvEpisode Episode { get; set; }
    public DateTime Updated { get; set; }
}