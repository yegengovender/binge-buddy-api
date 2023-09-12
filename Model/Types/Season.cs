using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

public class Season
{
    public int Id { get; set; }
    public int WebId { get; set; }
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
