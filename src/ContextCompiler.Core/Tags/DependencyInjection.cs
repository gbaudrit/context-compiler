using ContextCompiler.Abstractions.Tags;

using Microsoft.Extensions.DependencyInjection;

namespace ContextCompiler.Core.Tags;

public static class DependencyInjection
{

    public static IServiceCollection AddTags(this IServiceCollection services)
    {
        // Register core services here
        return services.AddSingleton<ITagBuilder, TagBuilder>()
                       .AddSingleton<ITagsBuilder, TagsBuilder>();
    }

}
