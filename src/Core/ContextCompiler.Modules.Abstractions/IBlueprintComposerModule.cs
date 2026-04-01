namespace ContextCompiler.Modules.Abstractions;

/// <summary>
/// Interface pour les modules qui fournissent des blueprints
/// </summary>
public interface IBlueprintComposerModule : IModule
{
    /// <summary>
    /// Lancement du module
    /// </summary>
    Task Run(CancellationToken cancellationToken);
}
