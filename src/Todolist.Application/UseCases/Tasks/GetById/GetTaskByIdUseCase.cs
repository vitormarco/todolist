using Todolist.Communication.Enums;
using Todolist.Communication.Responses;

namespace Todolist.Application.UseCases.Tasks.GetById;

public class GetTaskByIdUseCase
{
    public ResponseTaskJson Execute(int id)
    {
        return new ResponseTaskJson
        {
            Id = id,
            Name = "Task 1",
            Description = "Description of task 1",
            Deadline = new DateTime(year: 2025, month: 4, day: 1, hour: 18, minute: 0, second: 0),
            Priority = PriorityType.High,
            Status = StatusType.Pending
        };
    }
}
