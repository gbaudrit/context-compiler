using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class ModulesController : ControllerBase
{
    private readonly ICatalogService _catalog;

    public ModulesController(ICatalogService catalog) => _catalog = catalog;

    /// <summary>Returns all available modules.</summary>
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ModuleDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var items = await _catalog.GetModulesAsync();
        var dtos = items.Select(m => new ModuleDto(
            m.Id, m.Name, m.Description, m.Category, m.NuGetPackage, m.PipelinePhase))
            .ToList();
        return Ok(dtos);
    }

    /// <summary>Returns a single module by its ID.</summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ModuleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var items = await _catalog.GetModulesAsync();
        var item = items.FirstOrDefault(m => m.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (item is null) return NotFound();

        return Ok(new ModuleDto(
            item.Id, item.Name, item.Description,
            item.Category, item.NuGetPackage, item.PipelinePhase));
    }
}
