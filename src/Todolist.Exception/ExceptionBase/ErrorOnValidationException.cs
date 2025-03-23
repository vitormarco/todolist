namespace Todolist.Exception.ExceptionBase;

public class ErrorOnValidationException(List<string> errorMessages) : TasklistException
{
    public List<string> Errors { get; set; } = errorMessages;
}
