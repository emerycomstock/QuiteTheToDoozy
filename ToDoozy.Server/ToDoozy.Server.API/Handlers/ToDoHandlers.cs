using Microsoft.AspNetCore.Mvc;

public static class ToDoHandlers
{
    public static IResult GetToDoById(
        [FromRoute] int id)
    {
        throw new NotImplementedException();
    }

    public static IResult ListToDos(
        [FromQuery] int page,
        [FromQuery] int limit,
        [FromQuery] string status)
    {
        throw new NotImplementedException();
    }

    public static IResult CreateToDo(
        [FromBody] CreateToDoRequest createParams)
    {
        throw new NotImplementedException();
    }

    public static IResult UpdateToDo(
        [FromRoute] int id,
        [FromBody] UpdateToDoRequest updateParams)
    {
        throw new NotImplementedException();
    }

    public static IResult DeleteToDo(
        [FromRoute] int id)
    {
        throw new NotImplementedException();
    }
}