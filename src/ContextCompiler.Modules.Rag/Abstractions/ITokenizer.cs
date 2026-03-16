using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Abstractions;

internal interface ITokenizer
{
    Task<TokenizedText> Encode(string text);
}
