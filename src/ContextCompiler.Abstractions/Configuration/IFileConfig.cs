using System.Text.Json;

namespace ContextCompiler.Abstractions.Configuration;

public interface IFileConfig
{
    string[] Includes { get; set; }
    string[] Excludes { get; set; }
    ISubFilesMatchConfig[] Subs { get; set; }
    string[] Tags { get; set; }
    JsonElement? Options { get; set; }
}
