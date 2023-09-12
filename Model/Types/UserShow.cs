using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

public class UserShow
{
    public int Id { get; set; }

    [ForeignKey("UserId")]
    [JsonIgnore]
    public User User { get; set; }

    [ForeignKey("ShowId")]
    public Show Show { get; set; }

    public IEnumerable<UserShowActivity>? UserShowActivities { get; set; }
}
