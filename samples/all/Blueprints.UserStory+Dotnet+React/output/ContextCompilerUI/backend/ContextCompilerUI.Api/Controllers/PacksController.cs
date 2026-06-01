using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Models;
using ContextCompilerUI.Api.Services;

using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class PacksController(ICatalogService catalog) : ControllerBase
{
    private readonly ICatalogService _catalog = catalog;

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PackDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        IReadOnlyList<PackItem> items = await _catalog.GetPacksAsync();
        List<PackDto> dtos = [.. items.Select(p => new PackDto(p.Id, p.Name, p.Description, p.ModuleIds))];
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PackDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        IReadOnlyList<PackItem> items = await _catalog.GetPacksAsync();
        PackItem? item = items.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        return item is null ? NotFound() : Ok(new PackDto(item.Id, item.Name, item.Description, item.ModuleIds));
    }
}
