using Microsoft.AspNetCore.Mvc;

public static class UserHandlers
{
    public static IResult CreateUser(
        [FromBody] CreateUserRequest createParams)
    {
        throw new NotImplementedException();
    }

    public static IResult Login(
        [FromBody] LoginRequest loginParams)
    {
        throw new NotImplementedException();
    }
}