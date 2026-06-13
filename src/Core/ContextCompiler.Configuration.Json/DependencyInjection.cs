using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Abstractions.Sources;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Configuration.Json;

public static class DependencyInjection
{

    public static IServiceCollection AddJsonConfiguration(this IServiceCollection services, IConfigurationBuilder configurationBuilder, string inputPath, string? explicitConfigPath)
    {
        _ = configurationBuilder.AddWorkspaceJsonConfiguration(inputPath, explicitConfigPath);

        return services.AddSingleton<IConfigSerializer, CtxcConfigSerializer>()
            .AddTransient<IConfigurationSchemaAggregator, SchemaAggregator>()
            .AddSingleton<IConfigurationSchemaProvider, JsonConfigurationSchemaProvider>()
            .AddTransient<IConfigurationSchemasDiscoverer, JsonConfigurationSchemasDiscoverer>()
            .AddTransient<ISourceConfigSectionReader, JsonSourceConfigSectionReader>();
    }

    private static IConfigurationBuilder AddWorkspaceJsonConfiguration(this IConfigurationBuilder configuration, string inputPath, string? explicitConfigPath)
    {
        string workspacePath = string.IsNullOrWhiteSpace(inputPath)
            ? Environment.CurrentDirectory
            : inputPath;

        string workingFolderPath = Path.Combine(workspacePath, ".ctxc");

        IEnumerable<string> configFiles = Directory.GetFiles(workspacePath, "ctxc.*.config.json");
        configFiles = configFiles.Concat(Directory.GetFiles(workingFolderPath, "ctxc.*.config.json"));

        if (!string.IsNullOrWhiteSpace(explicitConfigPath))
        {
            configFiles = configFiles.Append(explicitConfigPath);
        }

        foreach (string configFile in configFiles)
        {
            _ = configuration.AddJsonFile(configFile, optional: false, reloadOnChange: true);
        }

        //if (!string.IsNullOrWhiteSpace(explicitConfigPath))
        //{
        //    AddJsonFilePair(configuration, Path.GetFullPath(explicitConfigPath), optional: false);
        //}
        //else
        //{
        //    AddJsonFilePair(configuration, Path.Combine(workingFolderPath, "ctxc.config.json"), optional: true);
        //    AddJsonFilePair(configuration, Path.Combine(workspacePath, "ctxc.config.json"), optional: true);
        //}

        //AddJsonFilePair(configuration, Path.Combine(workingFolderPath, "ctxc.modules.config.json"), optional: true);
        //AddJsonFilePair(configuration, Path.Combine(workspacePath, "ctxc.modules.config.json"), optional: true);
        //AddJsonFilePair(configuration, Path.Combine(workingFolderPath, "ctxc.modules.versions.json"), optional: true);
        //AddJsonFilePair(configuration, Path.Combine(workspacePath, "ctxc.modules.versions.json"), optional: true);
        //AddJsonFilePair(configuration, Path.Combine(workingFolderPath, "ctxc.skills.config.json"), optional: true);
        //AddJsonFilePair(configuration, Path.Combine(workspacePath, "ctxc.skills.config.json"), optional: true);

        return configuration;
    }

}
