## Domain Logic

The `ConsoleApp.MiniIssueTrackingSystemV2` is designed to simulate a simple issue tracking system within a console application environment. The domain logic is centered around the core concepts of **Issues**, **Users**, and **Comments** within the system.

### Issues
- **Creation**: Users can create new issues, providing a title and a description.
- **Status Management**: Each issue can be in one of several states: `Open`, `In Progress`, `Resolved`, or `Closed`. Users can update the status based on the progress.
- **Assignment**: Issues can be assigned to users, indicating who is responsible for addressing them.

### Users
- **Registration**: Users must register with the system to interact with issues. This includes providing a username and email.
- **Authentication**: Users can log in to the system to begin working on issues.
- **Authorization**: Certain actions, like closing an issue, may be restricted to users with specific roles.

### Comments
- **Adding Comments**: Users can add comments to issues to provide updates or ask questions.
- **Editing Comments**: Users can edit their own comments if needed.

### Persistence
- **Storage**: The system stores issues, users, and comments in memory, which means data will be lost when the application is closed.
- **Retrieval**: Users can view a list of all issues, or filter them based on status or assignment.

### Error Handling
- **Validation**: The system validates user input to ensure that all required fields are provided and correctly formatted.
- **Exceptions**: The system handles exceptions gracefully, providing meaningful error messages to the user.