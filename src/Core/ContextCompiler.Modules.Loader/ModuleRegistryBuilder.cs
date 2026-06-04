using ContextCompiler.Abstractions.DependencyInjection;
using ContextCompiler.Abstractions.Files;
using ContextCompiler.Abstractions.Output;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Modules.Abstractions.Loading;
using ContextCompiler.Modules.Abstractions.MCP;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions.Views;
using ContextCompiler.Modules.Abstractions.Views.Renderers;
using ContextCompiler.Skills.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ContextCompiler.Modules.Loader;

public sealed class ModuleRegistryBuilder : IModuleRegistryBuilder
{
    private readonly List<IDelayedFeatureDependencyInjection> _delayedFeatureDependencyInjections = [];
    private readonly List<Type> _moduleTypes = [];


    public void RegisterModuleServices(IContextCompilerBuilder contextCompilerBuilder, IEnumerable<Type> types)
    {
        IServiceCollection services = contextCompilerBuilder.Services;

        _ = services.AddSingleton<IModulesRegistry>(sp => new ModulesRegistry(sp));

        foreach (Type t in types)
        {
            if (t is null || t.IsAbstract || t.IsInterface)
            {
                continue;
            }

            if (typeof(IDependencyInjection).IsAssignableFrom(t))
            {
                IDependencyInjection registration = (IDependencyInjection)Activator.CreateInstance(t)!;
                _ = registration.RegisterServices(services);
                _ = registration.Configure(contextCompilerBuilder);
            }

            if (typeof(IDelayedFeatureDependencyInjection).IsAssignableFrom(t))
            {
                _delayedFeatureDependencyInjections.Add((IDelayedFeatureDependencyInjection)Activator.CreateInstance(t)!);
            }
            if (typeof(ICompilePipelineModule).IsAssignableFrom(t))
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient(typeof(ICompilePipelineModule), t));
            }

            if (typeof(IInputIngestionPipelineModule).IsAssignableFrom(t))
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient(typeof(IInputIngestionPipelineModule), t));
            }

            if (typeof(IDataPartPipelineModule).IsAssignableFrom(t))
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient(typeof(IDataPartPipelineModule), t));
            }

            if (typeof(IFileReader).IsAssignableFrom(t))
            {
                _ = services.AddTransient(t);
            }

            if (typeof(IDataReaderModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IDataReaderModule), t);
            }

            if (typeof(IEngineeringModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IEngineeringModule), t);
            }

            if (typeof(IFragmentProcessorModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IFragmentProcessorModule), t);
            }

            if (typeof(IViewModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewModule), t);
            }

            if (typeof(IViewRendererModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewRendererModule), t);
            }

            if (typeof(IViewDescriberModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewDescriberModule), t);
            }

            if (typeof(IViewRenderersModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IViewRenderersModule), t);
            }

            if (typeof(IGraphExporterModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IGraphExporterModule), t);
            }

            if (typeof(IOutputArtifactSerializer).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IOutputArtifactSerializer), t);
            }

            if (typeof(IConfigurationModule).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IConfigurationModule), t);
            }
            if (typeof(IMCPListResourcesHandler).IsAssignableFrom(t))
            {
                _ = services.AddTransient(typeof(IMCPListResourcesHandler), t);
            }
            if (typeof(ISkillProvider).IsAssignableFrom(t))
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient(typeof(ISkillProvider), t));
            }
            if (typeof(ISkillRequirementsProvider).IsAssignableFrom(t))
            {
                services.TryAddEnumerable(ServiceDescriptor.Transient(typeof(ISkillRequirementsProvider), t));
            }

            if (typeof(IModule).IsAssignableFrom(t))
            {
                _moduleTypes.Add(t);
            }
        }
    }

    public Task RunDelayedFeatureDependencyInjection(IContextCompilerBuilder contextCompilerBuilder)
    {
        foreach (IDelayedFeatureDependencyInjection delayedFeatureDependencyInjection in _delayedFeatureDependencyInjections)
        {
            _ = delayedFeatureDependencyInjection.DelayedRegisterServices(contextCompilerBuilder.Services, _moduleTypes);
        }

        return Task.CompletedTask;
    }
}
