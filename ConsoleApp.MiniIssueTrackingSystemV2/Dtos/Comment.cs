namespace ConsoleApp.MiniIssueTrackingSystemV2.Dtos;

public class Comment
{
    public string Text { get; private set; }
    public User CreatedBy { get; private set; }

    public Comment(string text, User createdBy)
    {
        Text = text;
        CreatedBy = createdBy;
    }

    public override string ToString()
    {
        return $"{CreatedBy}: {Text}";
    }
}
