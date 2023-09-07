using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public bool LoggedIn { get; set; }
    public IEnumerable<Show> Shows { get; set; } = new List<Show>();
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
    public TvEpisode? NextEpisode { get; set; }
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
    public Show Show { get; set; }
    public string WatchedDate { get; set; } = "";

}