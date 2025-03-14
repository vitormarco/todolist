using Todolist.Communication.Enums;

namespace Todolist.Communication.Responses;

public class ResponseShortTaskJson
{
    public int Id { get; set; }
    public PriorityType Priority { get; set; }
    public DateTime Deadline { get; set; }
    public StatusType Status { get; set; }
}
