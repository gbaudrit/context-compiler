namespace ContextCompiler.Abstractions.Configuration;

public interface ISubFilesMatchConfig
{
    string[] Includes { get; set; }
    string[] Excludes { get; set; }
    string[] Tags { get; set; }
}
