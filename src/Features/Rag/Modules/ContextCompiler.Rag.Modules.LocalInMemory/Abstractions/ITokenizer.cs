using ContextCompiler.Rag.Modules.LocalInMemory.Models;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

internal interface ITokenizer
{
    Task<TokenizedText> Encode(string text);

    int CountTokens(string text, bool considerPreTokenization = true, bool considerNormalization = true);

    IReadOnlyList<int> EncodeToIds(string text, bool considerPreTokenization = true, bool considerNormalization = true);

    string Decode(IEnumerable<int> ids);
}
