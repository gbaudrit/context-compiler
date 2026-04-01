using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class BlueprintsController : ControllerBase
{
    private readonly ICatalogService _catalog;

    public BlueprintsController(ICatalogService catalog) => _catalog = catalog;

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<BlueprintDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var items = await _catalog.GetBlueprintsAsync();
        var dtos = items.Select(Map).ToList();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BlueprintDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var items = await _catalog.GetBlueprintsAsync();
        var item = items.FirstOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (item is null) return NotFound();
        return Ok(Map(item));
    }

    private static BlueprintDto Map(Models.BlueprintItem b) => new(
        b.Id, b.Name, b.Description,
        b.Steps.Select(s => new BlueprintStepDto(s.Title, s.Description)).ToList(),
        b.Commands.Select(c => new BlueprintCommandDto(c.Name, c.Description, c.Example)).ToList(),
        b.PackIds);
}
