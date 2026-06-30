using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using ToDoozy.Server.API.DTOs;
using ToDoozy.Server.Common.Enums;
using ToDoozy.Server.Common.Exceptions;
using ToDoozy.Server.Data.Services;

public static class ToDoHandlers
{
    /**
     * API handler for ToDo get API.
     */
    public static async Task<IResult> GetToDoById(
        IToDoService service,
        ClaimsPrincipal user,
        UserManager<IdentityUser<int>> userManager,
        [FromRoute] int id)
    {
        try
        {
            var identityUser = await userManager.GetUserAsync(user);

            if (identityUser == null)
                return Results.Unauthorized();

            var entity = await service.GetToDoById(id, identityUser.Id);
            var result = GetToDoResponse.FromEntity(entity);

            return Results.Ok(result);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound();
        }
        catch (Exception)
        {
            return Results.InternalServerError();
        }
    }

    /**
     * API handler for ToDo list API. Supports pagination for up to 1,000,000 records (assumed maximum required).
     */
    public static async Task<IResult> ListToDos(
        IToDoService service,
        ClaimsPrincipal user,
        UserManager<IdentityUser<int>> userManager,
        [FromQuery, Range(1, 10000)] int page = 1,
        [FromQuery, Range(10, 100)] int limit = 20,
        [FromQuery] string? q = null,
        [FromQuery] string? status = null)
    {

        try
        {
            var identityUser = await userManager.GetUserAsync(user);

            if (identityUser == null)
                return Results.Unauthorized();

            var entities = await service.ListToDos(page, limit, q, ParseToDoStatuses(status), identityUser.Id);
            var result = ListToDosResponse.FromEntities(entities);

            return Results.Ok(result);
        }
        catch (BadRequestException)
        {
            return Results.BadRequest();
        }
        catch (Exception)
        {
            return Results.InternalServerError();
        }
    }

    /**
     * API handler for ToDo create API.
     */
    public static async Task<IResult> CreateToDo(
        IToDoService service,
        ClaimsPrincipal user,
        UserManager<IdentityUser<int>> userManager,
        [FromBody] CreateToDoRequest createParams)
    {
        try
        {
            var identityUser = await userManager.GetUserAsync(user);

            if (identityUser == null)
                return Results.Unauthorized();

            var entity = await service.CreateToDo(createParams.Title, createParams.Description, identityUser.Id);
            var result = CreateToDoResponse.FromEntity(entity);

            return Results.Ok(result);
        }
        catch (Exception)
        {
            return Results.InternalServerError();
        }
    }


    /**
     * API handler for ToDo update API.
     */
    public static async Task<IResult> UpdateToDo(
        IToDoService service,
        ClaimsPrincipal user,
        UserManager<IdentityUser<int>> userManager,
        [FromRoute] int id,
        [FromBody] UpdateToDoRequest updateParams)
    {
        try
        {
            var identityUser = await userManager.GetUserAsync(user);

            if (identityUser == null)
                return Results.Unauthorized();

            var entity = await service.UpdateToDo(id, updateParams.Title, updateParams.Description, updateParams.Status, identityUser.Id);
            var result = UpdateToDoResponse.FromEntity(entity);

            return Results.Ok(result);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound();
        }
        catch (Exception)
        {
            return Results.InternalServerError();
        }
    }

    /**
     * API handler for ToDo delete API.
     */
    public static async Task<IResult> DeleteToDo(
        IToDoService service,
        ClaimsPrincipal user,
        UserManager<IdentityUser<int>> userManager,
        [FromRoute] int id)
    {
        try
        {
            var identityUser = await userManager.GetUserAsync(user);

            if (identityUser == null)
                return Results.Unauthorized();

            await service.DeleteToDo(id, identityUser.Id);

            return Results.Ok();
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound();
        }
        catch (Exception)
        {
            return Results.InternalServerError();
        }
    }

    /**
     * Helper for parsing comma-separated string of statuses into an enumerable of enum values.
     * Throws BadRequestException if any status cannot be parsed.
     */
    private static IEnumerable<ToDoStatus>? ParseToDoStatuses(string? status)
    {
        // Use null to decline status filtering
        if (string.IsNullOrWhiteSpace(status)) return null;

        IList<ToDoStatus> statuses = [];
        foreach (var s in status.Split(','))
        {
            if (Enum.TryParse(s.Trim(), true, out ToDoStatus statusOut))
            {
                statuses.Add(statusOut);
            }
            else
            {
                throw new BadRequestException($"Value {s} is not a valid status.");
            }
        }

        return statuses;
    }
}