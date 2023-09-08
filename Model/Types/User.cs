public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public bool LoggedIn { get; set; }
    public IEnumerable<UserShow> UserShows { get; set; } = new List<UserShow>();
}
