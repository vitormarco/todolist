using CommonTestUtilities.Requests;
using FluentValidation;
using Shouldly;
using Todolist.Application.UseCases.Tasks.Register;
using Todolist.Communication.Enums;
using Todolist.Exception;

namespace Validators.Tests.Tasks.Register;

public class RegisterTaskValidatorTests
{

    [Fact]
    public void Success()
    {
        // Arrange
        var validator = new RegisterTaskValidator();
        var request = RequestRegisterTaskJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("             ")]
    [InlineData(null)]
    public void Error_Name_Empty(string? name)
    {
        // Arrange
        var validator = new RegisterTaskValidator();
        var request = RequestRegisterTaskJsonBuilder.Build();
        request.Name = name ?? string.Empty;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors
                .ShouldSatisfyAllConditions(
                    e => e.ShouldHaveSingleItem(),
                    e => e.ShouldContain(
                            message => message
                                        .ErrorMessage
                                        .Equals(ResourceErrorMessages.NAME_REQUIRED)
                         )
                );
    }

    [Fact]
    public void Error_Status_Type_Invalid()
    {
        // Arrange
        var validator = new RegisterTaskValidator();
        var request = RequestRegisterTaskJsonBuilder.Build();
        request.Status = (StatusType)99;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors
                .ShouldSatisfyAllConditions(
                    e => e.ShouldHaveSingleItem(),
                    e => e.ShouldContain(
                            message => message
                                        .ErrorMessage
                                        .Equals(ResourceErrorMessages.STATUS_INVALID)
                         )
                );
    }

    [Fact]
    public void Error_Deadline_Past()
    {
        // Arrange 
        var validator = new RegisterTaskValidator();
        var request = RequestRegisterTaskJsonBuilder.Build();
        request.Deadline = DateTime.UtcNow.AddDays(-1);

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors
                .ShouldSatisfyAllConditions(
                    e => e.ShouldHaveSingleItem(),
                    e => e.ShouldContain(
                            message => message
                                        .ErrorMessage
                                        .Equals(ResourceErrorMessages.DATE_CANNOT_BE_IN_PAST)
                         )
                );
    }

    [Fact]
    public void Error_Priority_Type_Invalid()
    {
        // Arrange 
        var validator = new RegisterTaskValidator();
        var request = RequestRegisterTaskJsonBuilder.Build();
        request.Priority = (PriorityType)99;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors
                .ShouldSatisfyAllConditions(
                    e => e.ShouldHaveSingleItem(),
                    e => e.ShouldContain(
                            message => message
                                        .ErrorMessage
                                        .Equals(ResourceErrorMessages.PRIORITY_INVALID)
                         )
                );
    }
}
