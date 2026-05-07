using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;
using ContextCompiler.Rag.Modules.LocalInMemory.Models;

using Microsoft.ML.Tokenizers;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Tokenizers;

internal sealed class MLTokenizer : ITokenizer
{
    private readonly Tokenizer _tokenizer;

    public MLTokenizer()
    {
        _tokenizer = TiktokenTokenizer.CreateForEncoding("cl100k_base");
    }

    public int CountTokens(string text, bool considerPreTokenization = true, bool considerNormalization = true)
    {
        return _tokenizer.CountTokens(text, considerPreTokenization, considerNormalization);
    }

    public Task<TokenizedText> Encode(string text)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<int> EncodeToIds(string text, bool considerPreTokenization = true, bool considerNormalization = true)
    {
        return _tokenizer.EncodeToIds(text, considerPreTokenization, considerNormalization);
    }

    public string Decode(IEnumerable<int> ids)
    {
        return _tokenizer.Decode(ids);
    }
}
