public class User {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public bool LoggedIn { get; set; }
    public IEnumerable<Show> Shows { get; set; } = new List<Show>();
}

public class Show {
    public int Id { get; set; }
    public string Name { get; set; } = "";
}