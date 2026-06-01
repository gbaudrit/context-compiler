using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Models;
using ContextCompilerUI.Api.Services;

using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class ArtifactsController(IArtifactsService artifacts, IConfiguration config) : ControllerBase
{
    private readonly IArtifactsService _artifacts = artifacts;
    private readonly IConfiguration _config = config;

    /// <summary>
    /// Returns the artifacts index from the configured path (artifacts.index.json).
    /// </summary>
    [HttpGet("index")]
    [ProducesResponseType(typeof(ArtifactsIndexDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetIndex() 
    {
        string path = _config["CatalogPaths:ArtifactsIndex"]!;
        ArtifactsIndex? index = await _artifacts.GetArtifactsIndexAsync(path);
        if (index is null)
        {
            return NotFound();
        }

        ArtifactsIndexDto dto = new(
            [.. index.Artifacts.Select(a => new ArtifactDto(
                a.Filename, a.Description, a.MimeType, a.Size, a.GeneratedBy))]);

        return Ok(dto);
    }
}
