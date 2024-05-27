using ConsoleApp.MiniIssueTrackingSystemV2.Dtos;

namespace ConsoleApp.MiniIssueTrackingSystemV2.Services;

public class IssueTrackingSystemService
{
    private List<User> users = new List<User>();
    private List<Issue> issues = new List<Issue>();
    private User loggedInUser = null;

    public void Run()
    {
        while (true)
        {
            if (loggedInUser == null)
            {
                ShowLoginMenu();
            }
            else
            {
                ShowMainMenu();
            }
        }
    }

    private void ShowLoginMenu()
    {
        Console.WriteLine("1. Register");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Exit");

        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                RegisterUser();
                break;
            case "2":
                LoginUser();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("1. Create Issue");
        Console.WriteLine("2. View Issues");
        Console.WriteLine("3. Add Comment");
        Console.WriteLine("4. Change Issue Status");
        Console.WriteLine("5. Assign Issue");
        Console.WriteLine("6. Logout");

        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                CreateIssue();
                break;
            case "2":
                ViewIssues();
                break;
            case "3":
                AddComment();
                break;
            case "4":
                ChangeIssueStatus();
                break;
            case "5":
                AssignIssue();
                break;
            case "6":
                loggedInUser = null;
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }

    private void RegisterUser()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();
        Console.Write("Enter email: ");
        var email = Console.ReadLine();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
        {
            Console.WriteLine("Username and email cannot be empty.");
            return;
        }

        users.Add(new User(username, email));
        Console.WriteLine("User registered successfully.");
    }

    private void LoginUser()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        loggedInUser = users.FirstOrDefault(u => u.Username == username);

        if (loggedInUser != null)
        {
            Console.WriteLine("Login successful.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    private void CreateIssue()
    {
        if (loggedInUser == null)
        {
            Console.WriteLine("You need to log in first.");
            return;
        }

        Console.Write("Enter issue title: ");
        var title = Console.ReadLine();
        Console.Write("Enter issue description: ");
        var description = Console.ReadLine();

        if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
        {
            Console.WriteLine("Title and description cannot be empty.");
            return;
        }

        issues.Add(new Issue(title, description, loggedInUser));
        Console.WriteLine("Issue created successfully.");
    }

    private void ViewIssues()
    {
        foreach (var issue in issues)
        {
            Console.WriteLine(issue);
        }
    }

    private void AddComment()
    {
        Console.Write("Enter issue ID: ");
        int issueId;
        if (!int.TryParse(Console.ReadLine(), out issueId))
        {
            Console.WriteLine("Invalid issue ID.");
            return;
        }

        var issue = issues.FirstOrDefault(i => i.Id == issueId);
        if (issue == null)
        {
            Console.WriteLine("Issue not found.");
            return;
        }

        Console.Write("Enter comment: ");
        var comment = Console.ReadLine();

        if (string.IsNullOrEmpty(comment))
        {
            Console.WriteLine("Comment cannot be empty.");
            return;
        }

        issue.AddComment(new Comment(comment, loggedInUser));
        Console.WriteLine("Comment added successfully.");
    }

    private void ChangeIssueStatus()
    {
        Console.Write("Enter issue ID: ");
        int issueId;
        if (!int.TryParse(Console.ReadLine(), out issueId))
        {
            Console.WriteLine("Invalid issue ID.");
            return;
        }

        var issue = issues.FirstOrDefault(i => i.Id == issueId);
        if (issue == null)
        {
            Console.WriteLine("Issue not found.");
            return;
        }

        Console.WriteLine("Select new status:");
        Console.WriteLine("1. Open");
        Console.WriteLine("2. In Progress");
        Console.WriteLine("3. Resolved");
        Console.WriteLine("4. Closed");

        var statusChoice = Console.ReadLine();
        IssueStatus newStatus;

        switch (statusChoice)
        {
            case "1":
                newStatus = IssueStatus.Open;
                break;
            case "2":
                newStatus = IssueStatus.InProgress;
                break;
            case "3":
                newStatus = IssueStatus.Resolved;
                break;
            case "4":
                newStatus = IssueStatus.Closed;
                break;
            default:
                Console.WriteLine("Invalid status choice.");
                return;
        }

        issue.Status = newStatus;
        Console.WriteLine("Issue status updated successfully.");
    }

    private void AssignIssue()
    {
        Console.Write("Enter issue ID: ");
        int issueId;
        if (!int.TryParse(Console.ReadLine(), out issueId))
        {
            Console.WriteLine("Invalid issue ID.");
            return;
        }

        var issue = issues.FirstOrDefault(i => i.Id == issueId);
        if (issue == null)
        {
            Console.WriteLine("Issue not found.");
            return;
        }

        Console.Write("Enter username to assign: ");
        var username = Console.ReadLine();
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        issue.AssignedTo = user;
        Console.WriteLine("Issue assigned successfully.");
    }
}
