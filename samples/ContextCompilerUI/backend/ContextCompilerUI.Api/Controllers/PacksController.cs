using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class PacksController : ControllerBase
{
    private readonly ICatalogService _catalog;

    public PacksController(ICatalogService catalog) => _catalog = catalog;

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<PackDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var items = await _catalog.GetPacksAsync();
        var dtos = items.Select(p => new PackDto(p.Id, p.Name, p.Description, p.ModuleIds)).ToList();
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PackDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var items = await _catalog.GetPacksAsync();
        var item = items.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (item is null) return NotFound();
        return Ok(new PackDto(item.Id, item.Name, item.Description, item.ModuleIds));
    }
}
