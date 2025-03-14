using Todolist.Communication.Enums;
using Todolist.Communication.Responses;

namespace Todolist.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTaskJson Execute()
    {
        return new ResponseAllTaskJson
        {
            Tasks = new List<ResponseShortTaskJson>
            {
                new ResponseShortTaskJson
                {
                    Id = 1,
                    Deadline = new DateTime(year: 2025, month: 4, day: 1, hour: 18, minute: 0, second: 0),
                    Priority = PriorityType.High,
                    Status = StatusType.Pending,
                },
                new ResponseShortTaskJson
                {
                    Id = 2,
                    Deadline = new DateTime(year: 2025, month: 3, day: 20, hour: 14, minute: 30, second: 0),
                    Priority = PriorityType.Medium,
                    Status = StatusType.InProgress,
                }
            }
        };
    }
}
