using System.ComponentModel.DataAnnotations.Schema;

public class Show
{
    public int Id { get; set; }
    public int WebId { get; set; }
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
    public IEnumerable<TvEpisode?> TvEpisodes { get; set; }
    public IEnumerable<Season> Seasons { get; set; }
}
