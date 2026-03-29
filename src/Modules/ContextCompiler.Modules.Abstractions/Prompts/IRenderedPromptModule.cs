namespace ContextCompiler.Modules.Abstractions.Prompts
{
    public interface IRenderedPromptModule
    {
        string RenderedText { get; init; }
        string Filename { get; init; }
    }
}
