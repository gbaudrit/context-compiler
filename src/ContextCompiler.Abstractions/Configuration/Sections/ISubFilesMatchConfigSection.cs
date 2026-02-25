namespace ContextCompiler.Abstractions.Configuration.Sections;

public interface ISubFilesMatchConfigSection
{
    string[] Includes { get; set; }
    string[] Excludes { get; set; }
    string[] Tags { get; set; }
}
