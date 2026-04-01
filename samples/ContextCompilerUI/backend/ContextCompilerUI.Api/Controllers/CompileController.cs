using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class CompileController : ControllerBase
{
    private readonly ICatalogService _catalog;
    private readonly ILogger<CompileController> _logger;

    public CompileController(ICatalogService catalog, ILogger<CompileController> logger)
    {
        _catalog = catalog;
        _logger = logger;
    }

    /// <summary>
    /// Compiles a prompt context from a selection of modules, packs and blueprints.
    /// In v1 this builds a Markdown representation; a full ctxc runtime call can be wired here later.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(CompileResultDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Compile([FromBody] CompileRequestDto request)
    {
        if (request.ModuleIds.Count == 0
            && request.PackIds.Count == 0
            && request.BlueprintIds.Count == 0)
        {
            return BadRequest("At least one module, pack or blueprint must be selected.");
        }

        try
        {
            var (modules, packs, blueprints) = await LoadSelectionAsync(request);
            var prompt = BuildPromptContext(modules, packs, blueprints);

            var artifacts = new ArtifactsIndexDto(
            [
                new ArtifactDto("prompt.context.md", "", "text/markdown", prompt.Length, "ContextCompilerUI.Api")
            ]);

            return Ok(new CompileResultDto(prompt, artifacts, true, null));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Compile failed");
            return Ok(new CompileResultDto(string.Empty, new ArtifactsIndexDto([]), false, ex.Message));
        }
    }

    // --- private ---

    private async Task<(
        IEnumerable<Models.ModuleItem> Modules,
        IEnumerable<Models.PackItem> Packs,
        IEnumerable<Models.BlueprintItem> Blueprints)>
        LoadSelectionAsync(CompileRequestDto request)
    {
        var allModules = await _catalog.GetModulesAsync();
        var allPacks = await _catalog.GetPacksAsync();
        var allBlueprints = await _catalog.GetBlueprintsAsync();

        var selectedModules = allModules
            .Where(m => request.ModuleIds.Contains(m.Id, StringComparer.OrdinalIgnoreCase));

        var selectedPacks = allPacks
            .Where(p => request.PackIds.Contains(p.Id, StringComparer.OrdinalIgnoreCase));

        var selectedBlueprints = allBlueprints
            .Where(b => request.BlueprintIds.Contains(b.Id, StringComparer.OrdinalIgnoreCase));

        return (selectedModules, selectedPacks, selectedBlueprints);
    }

    private static string BuildPromptContext(
        IEnumerable<Models.ModuleItem> modules,
        IEnumerable<Models.PackItem> packs,
        IEnumerable<Models.BlueprintItem> blueprints)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("# Compiled Prompt Context");
        sb.AppendLine();

        if (blueprints.Any())
        {
            sb.AppendLine("# Blueprints");
            foreach (var bp in blueprints)
            {
                sb.AppendLine($"## {bp.Name} ({bp.Id})");
                sb.AppendLine(bp.Description);
                sb.AppendLine();
                int i = 1;
                foreach (var step in bp.Steps)
                {
                    sb.AppendLine($"### Step {i++}: {step.Title}");
                    sb.AppendLine(step.Description);
                    sb.AppendLine();
                }
            }
        }

        if (packs.Any())
        {
            sb.AppendLine("# Packs");
            foreach (var p in packs)
            {
                sb.AppendLine($"- **{p.Name}**: {p.Description}");
            }
            sb.AppendLine();
        }

        if (modules.Any())
        {
            sb.AppendLine("# Modules");
            foreach (var m in modules)
            {
                sb.AppendLine($"- **{m.Name}** [{m.Category}/{m.PipelinePhase}]: {m.Description}");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
