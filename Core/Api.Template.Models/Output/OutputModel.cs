using Microsoft.AspNetCore.Mvc;

namespace Api.Template.Models.Output;

public record OutputModel
{
    public static implicit operator ActionResult(OutputModel model) => new OkObjectResult(model);
}
