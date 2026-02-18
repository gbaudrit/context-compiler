namespace ContextCompiler.Plugins.Abstractions.Prompts
{
    public interface IRenderedPromptResult
    {
        string RenderedText { get; init; }
        string Filename { get; init; }
    }
}
