namespace ConsoleApp.MiniIssueTrackingSystemV2.Dtos;

public class Issue
{
    private static int nextId = 1;
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public User CreatedBy { get; private set; }
    public IssueStatus Status { get; set; }
    public User AssignedTo { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Issue(string title, string description, User createdBy)
    {
        Id = nextId++;
        Title = title;
        Description = description;
        CreatedBy = createdBy;
        Status = IssueStatus.Open;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public override string ToString()
    {
        var assignedTo = AssignedTo == null ? "None" : AssignedTo.Username;
        return $"ID: {Id}, Title: {Title}, Description: {Description}, Status: {Status}, Created By: {CreatedBy}, Assigned To: {assignedTo}, Comments: {comments.Count}";
    }
}
