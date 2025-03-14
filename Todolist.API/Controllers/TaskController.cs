using Microsoft.AspNetCore.Mvc;
using Todolist.Application.UseCases.Tasks.DeleteById;
using Todolist.Application.UseCases.Tasks.GetAll;
using Todolist.Application.UseCases.Tasks.GetById;
using Todolist.Application.UseCases.Tasks.Register;
using Todolist.Application.UseCases.Tasks.Update;
using Todolist.Communication.Requests;
using Todolist.Communication.Responses;

namespace Todolist.API.Controllers;
public class TaskController : TodolistApiBaseController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestTaskJson request)
    {
        var response = new RegisterTaskUseCase().Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var response = new GetAllTasksUseCase().Execute();
        if (response.Tasks.Count > 0) return Ok(response);

        return NotFound();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById([FromRoute] int id)
    {
        var response = new GetTaskByIdUseCase().Execute(id);
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestTaskJson request)
    {
        new UpdateTaskUseCase().Execute(id: id, request: request);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        new DeleteTaskByIdUseCase().Execute(id);
        return NoContent();
    }
}
