using Microsoft.AspNetCore.Mvc;

namespace Todolist.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class TodolistApiBaseController : ControllerBase
{
}
