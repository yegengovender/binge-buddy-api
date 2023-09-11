using Newtonsoft.Json;

public record UserRequest(
    [property: JsonProperty("id")] int Id,
    [property: JsonProperty("loggedIn")] bool LoggedIn,
    [property: JsonProperty("shows")] IEnumerable<ShowRequest> Shows,
    [property: JsonProperty("userShows")] IEnumerable<UserShowRequest> UserShows
)
{
    private readonly List<UserShowRequest>? userShowRequests;
    private List<ShowRequest>? shows;

    public UserRequest(
        [param: JsonProperty("id")] int id,
        [param: JsonProperty("name")] string name,
        [param: JsonProperty("email")] string email,
        [param: JsonProperty("loggedIn")] bool loggedIn,
        [param: JsonProperty("showa")] List<ShowRequest> shows,
        [param: JsonProperty("userShows")] List<UserShowRequest> userShowRequests
    )
        : this(id, loggedIn, shows, userShowRequests)
    {
        Id = id;
        Name = name;
        Email = email;
        LoggedIn = loggedIn;
        this.shows = shows;
        this.userShowRequests = userShowRequests;
    }

    [JsonProperty("name")]
    public string Name { get; set; } = "";
    
    [JsonProperty("email")]
    public string Email { get; set; } = "";
}
