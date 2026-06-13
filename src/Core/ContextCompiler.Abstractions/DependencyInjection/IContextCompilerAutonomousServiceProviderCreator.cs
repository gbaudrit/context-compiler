namespace ContextCompiler.Abstractions.DependencyInjection;

public interface IContextCompilerAutonomousServiceProviderCreator
{

    Task<IServiceProvider> WithModulesLoaded(CancellationToken cancellationToken);

}
