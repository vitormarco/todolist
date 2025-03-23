using Bogus;
using Todolist.Communication.Enums;
using Todolist.Communication.Requests;

namespace CommonTestUtilities.Requests;

public static class RequestRegisterTaskJsonBuilder
{

    public static RequestTaskJson Build()
    {
        return new Faker<RequestTaskJson>()
                    .RuleFor(request => request.Name, faker => faker.Lorem.Text())
                    .RuleFor(request => request.Description, faker => faker.Lorem.Paragraph())
                    .RuleFor(request => request.Status, faker => faker.PickRandom<StatusType>())
                    .RuleFor(request => request.Deadline, faker => faker.Date.Future())
                    .RuleFor(request => request.Priority, faker => faker.PickRandom<PriorityType>());
    }
}
