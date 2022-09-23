using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoServices _service;

    public TodoController(TodoServices service)
    {
        _service = service;
    }


    [HttpGet("Getallfromtodo")]
    public async Task<string> Get()

    {
        return await _service.Getallfromtodo();
    }




    [HttpPut("UpdateTodo")]
    public async Task<string> Put(Todo todo)

    {
        return await _service.UpdateTodo(todo);
    }










    [HttpDelete("DeleteTodo")]
    public async Task<string> Delete(int id)

    {
        return await _service.DeleteTodo(id);
    }






    [HttpPost("AddTodo")]
    public async Task<string> Create(Todo todo)
    {
        return await _service.AddTodo(todo);

    }







}
