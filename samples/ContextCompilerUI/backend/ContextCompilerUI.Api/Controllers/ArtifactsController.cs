using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class ArtifactsController : ControllerBase
{
    private readonly IArtifactsService _artifacts;
    private readonly IConfiguration _config;

    public ArtifactsController(IArtifactsService artifacts, IConfiguration config)
    {
        _artifacts = artifacts;
        _config = config;
    }

    /// <summary>
    /// Returns the artifacts index from the configured path (artifacts.index.json).
    /// </summary>
    [HttpGet("index")]
    [ProducesResponseType(typeof(ArtifactsIndexDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetIndex()
    {
        var path = _config["CatalogPaths:ArtifactsIndex"]!;
        var index = await _artifacts.GetArtifactsIndexAsync(path);
        if (index is null) return NotFound();

        var dto = new ArtifactsIndexDto(
            index.Artifacts.Select(a => new ArtifactDto(
                a.Filename, a.Description, a.MimeType, a.Size, a.GeneratedBy))
            .ToList());

        return Ok(dto);
    }
}
