using Todolist.Communication.Enums;

namespace Todolist.Communication.Requests;

public class RequestTaskJson
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public PriorityType Priority { get; set; }
    public DateTime Deadline { get; set; }
    public StatusType Status { get; set; }
}
