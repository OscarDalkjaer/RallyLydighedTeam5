using Microsoft.AspNetCore.Mvc;

namespace RallyTests;

public static class ActionResultExtensions
{
    public static T GetValueAs<T>(this IActionResult result)
    {
        if (result is OkObjectResult)
        {
            var okResult = (OkObjectResult)result;
            return (T)okResult.Value!;
        }

        return default!;
    }

    public static T GetValueAs<T>(this ActionResult<T> result)
    {
        return result.Result!.GetValueAs<T>();
    }
}
