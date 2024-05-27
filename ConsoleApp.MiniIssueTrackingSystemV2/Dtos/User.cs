namespace ConsoleApp.MiniIssueTrackingSystemV2.Dtos;

public class User
{
    public string Username { get; private set; }
    public string Email { get; private set; }

    public User(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public override string ToString()
    {
        return Username;
    }
}
