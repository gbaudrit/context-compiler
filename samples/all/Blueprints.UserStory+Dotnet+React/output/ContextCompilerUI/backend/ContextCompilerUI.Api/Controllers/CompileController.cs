using System.Globalization;
using System.Text;

using ContextCompilerUI.Api.DTOs;
using ContextCompilerUI.Api.Models;
using ContextCompilerUI.Api.Services;

using Microsoft.AspNetCore.Mvc;

namespace ContextCompilerUI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public sealed class CompileController(ICatalogService catalog, ILogger<CompileController> logger) : ControllerBase
{
    private readonly ICatalogService _catalog = catalog;
    private readonly ILogger<CompileController> _logger = logger;

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
            (IEnumerable<ModuleItem>? modules, IEnumerable<PackItem>? packs, IEnumerable<BlueprintItem>? blueprints) = await LoadSelectionAsync(request);
            string prompt = BuildPromptContext(modules, packs, blueprints);

            ArtifactsIndexDto artifacts = new(
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
        IEnumerable<ModuleItem> Modules,
        IEnumerable<PackItem> Packs,
        IEnumerable<BlueprintItem> Blueprints)>
        LoadSelectionAsync(CompileRequestDto request)
    {
        IReadOnlyList<ModuleItem> allModules = await _catalog.GetModulesAsync();
        IReadOnlyList<PackItem> allPacks = await _catalog.GetPacksAsync();
        IReadOnlyList<BlueprintItem> allBlueprints = await _catalog.GetBlueprintsAsync();

        IEnumerable<ModuleItem> selectedModules = allModules
            .Where(m => request.ModuleIds.Contains(m.Id, StringComparer.OrdinalIgnoreCase));

        IEnumerable<PackItem> selectedPacks = allPacks
            .Where(p => request.PackIds.Contains(p.Id, StringComparer.OrdinalIgnoreCase));

        IEnumerable<BlueprintItem> selectedBlueprints = allBlueprints
            .Where(b => request.BlueprintIds.Contains(b.Id, StringComparer.OrdinalIgnoreCase));

        return (selectedModules, selectedPacks, selectedBlueprints);
    }

    private static string BuildPromptContext(
        IEnumerable<ModuleItem> modules,
        IEnumerable<PackItem> packs,
        IEnumerable<BlueprintItem> blueprints)
    {
        StringBuilder sb = new();
        _ = sb.AppendLine("# Compiled Prompt Context");
        _ = sb.AppendLine();

        if (blueprints.Any())
        {
            _ = sb.AppendLine("# Blueprints");
            foreach (BlueprintItem bp in blueprints)
            {
                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"## {bp.Name} ({bp.Id})");
                _ = sb.AppendLine(bp.Description);
                _ = sb.AppendLine();
                int i = 1;
                foreach (BlueprintStep step in bp.Steps)
                {
                    _ = sb.AppendLine(CultureInfo.InvariantCulture, $"### Step {i++}: {step.Title}");
                    _ = sb.AppendLine(step.Description);
                    _ = sb.AppendLine();
                }
            }
        }

        if (packs.Any())
        {
            _ = sb.AppendLine("# Packs");
            foreach (PackItem p in packs)
            {
                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- **{p.Name}**: {p.Description}");
            }
            _ = sb.AppendLine();
        }

        if (modules.Any())
        {
            _ = sb.AppendLine("# Modules");
            foreach (ModuleItem m in modules)
            {
                _ = sb.AppendLine(CultureInfo.InvariantCulture, $"- **{m.Name}** [{m.Category}/{m.PipelinePhase}]: {m.Description}");
            }
            _ = sb.AppendLine();
        }

        return sb.ToString();
    }
}
