
using Newtonsoft.Json;

public class User
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("email")]
    public string? Email { get; set; }

    [JsonProperty("loggedIn")]
    public bool LoggedIn { get; set; }

    [JsonProperty("shows")]
    public IEnumerable<Show>? Shows { get; set; }

    [JsonProperty("userShows")]
    public IEnumerable<UserShow>? UserShows { get; set; }

}
