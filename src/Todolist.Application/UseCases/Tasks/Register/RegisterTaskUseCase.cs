using Todolist.Communication.Requests;
using Todolist.Communication.Responses;
using Todolist.Exception.ExceptionBase;

namespace Todolist.Application.UseCases.Tasks.Register;

public class RegisterTaskUseCase
{
    public ResponseRegisterTaskJson Execute(RequestTaskJson request)
    {

        Validate(request: request);

        return new ResponseRegisterTaskJson
        {
            Id = new Random().Next(),
            Name = request.Name
        };
    }

    private static void Validate(RequestTaskJson request)
    {
        var validator = new RegisterTaskValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors
                                    .Select(error => error.ErrorMessage)
                                    .ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
