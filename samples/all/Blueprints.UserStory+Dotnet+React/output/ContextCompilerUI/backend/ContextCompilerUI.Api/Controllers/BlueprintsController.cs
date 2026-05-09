using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Models;
using ContextCompilerUI.Api.Services;

using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class BlueprintsController(ICatalogService catalog) : ControllerBase
{
    private readonly ICatalogService _catalog = catalog;

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<BlueprintDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        IReadOnlyList<BlueprintItem> items = await _catalog.GetBlueprintsAsync();
        List<BlueprintDto> dtos = [.. items.Select(Map)];
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BlueprintDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        IReadOnlyList<BlueprintItem> items = await _catalog.GetBlueprintsAsync();
        BlueprintItem? item = items.FirstOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        return item is null ? NotFound() : Ok(Map(item));
    }

    private static BlueprintDto Map(BlueprintItem b)
    {
        return new(
        b.Id, b.Name, b.Description,
        [.. b.Steps.Select(s => new BlueprintStepDto(s.Title, s.Description))],
        [.. b.Commands.Select(c => new BlueprintCommandDto(c.Name, c.Description, c.Example))],
        b.PackIds);
    }
}
