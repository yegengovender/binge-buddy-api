using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

public class TvEpisode
{
    public int Id { get; set; }
    public int WebId { get; set; }
    public string Name { get; set; } = "";
    public int SeasonId { get; set; }
    public int Number { get; set; }
    public string Airdate { get; set; } = "";
    public int Runtime { get; set; }
    public float Rating { get; set; }
    public string Image { get; set; } = "";
    public string Summary { get; set; } = "";
    public int ShowId { get; set; }
    [ForeignKey("ShowId")]
    [JsonIgnore]
    public Show Show { get; set; }
}
