using Todolist.Communication.Requests;
using Todolist.Communication.Responses;

namespace Todolist.Application.UseCases.Tasks.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTaskJson Execute(RequestTaskJson request)
    {
        return new ResponseRegisterTaskJson
        {
            Id = 1,
            Name = request.Name
        };
    }
}
