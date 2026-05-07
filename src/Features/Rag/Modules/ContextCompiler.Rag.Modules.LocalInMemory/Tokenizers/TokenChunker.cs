using System.Text;

using ContextCompiler.Rag.Modules.LocalInMemory.Abstractions;

namespace ContextCompiler.Rag.Modules.LocalInMemory.Tokenizers;

internal sealed class TokenChunker(ITokenizer tokenizer) : ITokenChunker
{

    public Task<IReadOnlyList<string>> SplitChunksByToken(
    string text,
    int maxTokens = 500,
    int overlapTokens = 80, CancellationToken cancellationToken = default)
    {
        List<string> chunks = [];

        if (string.IsNullOrWhiteSpace(text))
        {
            return Task.FromResult<IReadOnlyList<string>>(chunks.AsReadOnly());
        }

        // Split simple et rapide : paragraphes puis lignes si besoin
        string[] parts = text
            .Replace("\r\n", "\n")
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        List<string> currentParts = [];
        int currentTokenCount = 0;

        foreach (string part in parts)
        {
            int partTokenCount = tokenizer.CountTokens(part);

            // Si un paragraphe dépasse la taille max, on le coupe plus finement
            if (partTokenCount > maxTokens)
            {
                FlushCurrentChunk(chunks, currentParts);

                List<string> subChunks = SplitLargePart(part, maxTokens, overlapTokens);
                chunks.AddRange(subChunks);

                currentParts.Clear();
                currentTokenCount = 0;
                continue;
            }

            if (currentTokenCount + partTokenCount <= maxTokens)
            {
                currentParts.Add(part);
                currentTokenCount += partTokenCount;
            }
            else
            {
                FlushCurrentChunk(chunks, currentParts);

                // overlap léger basé sur le chunk précédent
                if (overlapTokens > 0 && chunks.Count > 0)
                {
                    string overlapText = TakeLastTokens(chunks[^1], overlapTokens);
                    currentParts.Clear();

                    if (!string.IsNullOrWhiteSpace(overlapText))
                    {
                        currentParts.Add(overlapText);
                        currentTokenCount = tokenizer.CountTokens(overlapText);
                    }
                    else
                    {
                        currentTokenCount = 0;
                    }
                }
                else
                {
                    currentParts.Clear();
                    currentTokenCount = 0;
                }

                currentParts.Add(part);
                currentTokenCount += partTokenCount;
            }
        }

        FlushCurrentChunk(chunks, currentParts);
        return Task.FromResult<IReadOnlyList<string>>(chunks.AsReadOnly());
    }

    private List<string> SplitLargePart(
        string text,
        int maxTokens,
        int overlapTokens)
    {
        List<string> result = [];

        // Découpe grossière par phrases / lignes
        string[] units = text
            .Replace("\r\n", "\n")
            .Split(
                [". ", "! ", "? ", "\n"],
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        StringBuilder current = new();
        int currentTokens;

        foreach (string unit in units)
        {
            string candidate = current.Length == 0 ? unit : current + " " + unit;
            int candidateTokens = tokenizer.CountTokens(candidate);

            if (candidateTokens <= maxTokens)
            {
                if (current.Length > 0)
                {
                    _ = current.Append(' ');
                }

                _ = current.Append(unit);
                currentTokens = candidateTokens;
            }
            else
            {
                if (current.Length > 0)
                {
                    result.Add(current.ToString());
                }

                // Si même une "unit" est trop grosse, fallback par mots
                if (tokenizer.CountTokens(unit) > maxTokens)
                {
                    result.AddRange(SplitByWords(unit, maxTokens, overlapTokens));
                    _ = current.Clear();
                    currentTokens = 0;
                }
                else
                {
                    _ = current.Clear();
                    _ = current.Append(unit);
                    currentTokens = tokenizer.CountTokens(unit);
                }
            }
        }

        if (current.Length > 0)
        {
            result.Add(current.ToString());
        }

        return result;
    }

    private List<string> SplitByWords(
        string text,
        int maxTokens,
        int overlapTokens)
    {
        List<string> result = [];
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        List<string> currentWords = [];

        foreach (string word in words)
        {
            string[] candidateWords = currentWords.Count == 0
                ? [word]
                : [.. currentWords, word];

            string candidate = string.Join(" ", candidateWords);

            if (tokenizer.CountTokens(candidate) <= maxTokens)
            {
                currentWords.Add(word);
            }
            else
            {
                if (currentWords.Count > 0)
                {
                    result.Add(string.Join(" ", currentWords));
                }

                if (overlapTokens > 0 && result.Count > 0)
                {
                    string overlap = TakeLastTokens(result[^1], overlapTokens);
                    currentWords = string.IsNullOrWhiteSpace(overlap)
                        ? []
                        : [.. overlap.Split(' ', StringSplitOptions.RemoveEmptyEntries)];
                }
                else
                {
                    currentWords = [];
                }

                currentWords.Add(word);
            }
        }

        if (currentWords.Count > 0)
        {
            result.Add(string.Join(" ", currentWords));
        }

        return result;
    }

    private string TakeLastTokens(string text, int tokenCount)
    {
        IReadOnlyList<int> encoded = tokenizer.EncodeToIds(text);
        if (encoded.Count <= tokenCount)
        {
            return text;
        }

        List<int> tail = [.. encoded.Skip(encoded.Count - tokenCount)];
        return tokenizer.Decode(tail);
    }

    private static void FlushCurrentChunk(List<string> chunks, List<string> currentParts)
    {
        if (currentParts.Count == 0)
        {
            return;
        }

        string chunk = string.Join("\n\n", currentParts).Trim();
        if (!string.IsNullOrWhiteSpace(chunk))
        {
            chunks.Add(chunk);
        }

        currentParts.Clear();
    }
}
//public async Task<IReadOnlyList<string>> SplitChunksByToken(
//    string text,
//    int maxTokens = 128,
//    int overlapTokens = 64,
//    CancellationToken cancellationToken = default)
//{
//    if (string.IsNullOrWhiteSpace(text))
//    {
//        return [];
//    }

//    if (maxTokens > 0)
//    {
//        if (overlapTokens < 0 || overlapTokens >= maxTokens)
//        {
//            throw new ArgumentOutOfRangeException(nameof(overlapTokens));
//        }

//        // Normalisation légère
//        text = NormalizeText(text);

//        // 1) On commence par des paragraphes
//        List<string> paragraphs = SplitParagraphs(text);

//        List<string> chunks = [];
//        StringBuilder currentChunk = new();

//        foreach (string paragraph in paragraphs)
//        {
//            cancellationToken.ThrowIfCancellationRequested();

//            // Si le paragraphe rentre seul, on essaie de l'ajouter au chunk courant
//            if (await CountTokensAsync(paragraph, tokenizer) <= maxTokens)
//            {
//                string candidate = currentChunk.Length == 0
//                    ? paragraph
//                    : currentChunk.ToString() + Environment.NewLine + Environment.NewLine + paragraph;

//                if (await CountTokensAsync(candidate, tokenizer) <= maxTokens)
//                {
//                    if (currentChunk.Length > 0)
//                    {
//                        _ = currentChunk.AppendLine().AppendLine();
//                    }

//                    _ = currentChunk.Append(paragraph);
//                }
//                else
//                {
//                    // Flush du chunk courant
//                    if (currentChunk.Length > 0)
//                    {
//                        chunks.Add(currentChunk.ToString());
//                    }

//                    // Nouveau chunk avec overlap depuis le précédent
//                    string overlapText = chunks.Count > 0
//                        ? await BuildOverlapTextAsync(chunks[^1], tokenizer, overlapTokens)
//                        : string.Empty;

//                    _ = currentChunk.Clear();

//                    if (!string.IsNullOrWhiteSpace(overlapText))
//                    {
//                        _ = currentChunk.Append(overlapText);

//                        string withParagraph = currentChunk.ToString() + Environment.NewLine + Environment.NewLine + paragraph;
//                        if (await CountTokensAsync(withParagraph, tokenizer) <= maxTokens)
//                        {
//                            _ = currentChunk.AppendLine().AppendLine().Append(paragraph);
//                        }
//                        else
//                        {
//                            _ = currentChunk.Clear();
//                            _ = currentChunk.Append(paragraph);
//                        }
//                    }
//                    else
//                    {
//                        _ = currentChunk.Append(paragraph);
//                    }
//                }
//            }
//            else
//            {
//                // Paragraphe trop gros : on flush le chunk courant d'abord
//                if (currentChunk.Length > 0)
//                {
//                    chunks.Add(currentChunk.ToString());
//                    _ = currentChunk.Clear();
//                }

//                // Puis on split ce paragraphe en sous-chunks
//                List<string> subChunks = await SplitLargeBlockByWords(
//                    paragraph,
//                    tokenizer,
//                    maxTokens,
//                    overlapTokens,
//                    cancellationToken);

//                chunks.AddRange(subChunks);
//            }
//        }

//        if (currentChunk.Length > 0)
//        {
//            chunks.Add(currentChunk.ToString());
//        }

//        return chunks;
//    }

//    throw new ArgumentOutOfRangeException(nameof(maxTokens));
//}

//private static async Task<List<string>> SplitLargeBlockByWords(
//    string text,
//    ITokenizer tokenizer,
//    int maxTokens,
//    int overlapTokens,
//    CancellationToken cancellationToken)
//{
//    List<string> words = SplitWords(text);
//    List<string> chunks = [];

//    int start = 0;

//    while (start < words.Count)
//    {
//        cancellationToken.ThrowIfCancellationRequested();

//        int bestEnd = await FindLargestFittingWordRange(words, start, tokenizer, maxTokens);

//        if (bestEnd <= start)
//        {
//            // Sécurité : si même un seul mot "ne passe pas",
//            // on force l'avance pour éviter une boucle infinie
//            bestEnd = start + 1;
//        }

//        string chunk = JoinWords(words, start, bestEnd);
//        chunks.Add(chunk);

//        if (bestEnd >= words.Count)
//        {
//            break;
//        }

//        // Calcul du nouveau start avec overlap en tokens
//        int overlapStart = await FindOverlapStartByTokenBudget(
//            words,
//            start,
//            bestEnd,
//            tokenizer,
//            overlapTokens);

//        start = overlapStart < bestEnd ? overlapStart : bestEnd;
//    }

//    return chunks;
//}

//private static async Task<int> FindLargestFittingWordRange(
//    List<string> words,
//    int start,
//    ITokenizer tokenizer,
//    int maxTokens)
//{
//    int low = start + 1;
//    int high = words.Count;
//    int best = start + 1;

//    while (low <= high)
//    {
//        int mid = low + ((high - low) / 2);
//        string candidate = JoinWords(words, start, mid);
//        int tokenCount = await CountTokensAsync(candidate, tokenizer);

//        if (tokenCount <= maxTokens)
//        {
//            best = mid;
//            low = mid + 1;
//        }
//        else
//        {
//            high = mid - 1;
//        }
//    }

//    return best;
//}

//private static async Task<int> FindOverlapStartByTokenBudget(
//    List<string> words,
//    int chunkStart,
//    int chunkEnd,
//    ITokenizer tokenizer,
//    int overlapTokens)
//{
//    if (overlapTokens <= 0)
//    {
//        return chunkEnd;
//    }

//    int start = chunkEnd - 1;
//    int bestStart = chunkEnd;

//    while (start >= chunkStart)
//    {
//        string candidate = JoinWords(words, start, chunkEnd);
//        int tokens = await CountTokensAsync(candidate, tokenizer);

//        if (tokens > overlapTokens)
//        {
//            break;
//        }

//        bestStart = start;
//        start--;
//    }

//    return bestStart;
//}

//private static async Task<string> BuildOverlapTextAsync(
//    string previousChunk,
//    ITokenizer tokenizer,
//    int overlapTokens)
//{
//    if (string.IsNullOrWhiteSpace(previousChunk) || overlapTokens <= 0)
//    {
//        return string.Empty;
//    }

//    List<string> words = SplitWords(previousChunk);
//    int start = words.Count - 1;
//    int bestStart = words.Count;

//    while (start >= 0)
//    {
//        string candidate = JoinWords(words, start, words.Count);
//        int tokenCount = await CountTokensAsync(candidate, tokenizer);

//        if (tokenCount > overlapTokens)
//        {
//            break;
//        }

//        bestStart = start;
//        start--;
//    }

//    return bestStart < words.Count
//        ? JoinWords(words, bestStart, words.Count)
//        : string.Empty;
//}

//private static async Task<int> CountTokensAsync(string text, ITokenizer tokenizer)
//{
//    TokenizedText encoded = await tokenizer.Encode(text);
//    return encoded.InputIds.Length;
//}

//private static string NormalizeText(string text)
//{
//    return text
//        .Replace("\r\n", "\n")
//        .Replace('\r', '\n')
//        .Trim();
//}

//private static List<string> SplitParagraphs(string text)
//{
//    return [.. text
//        .Split(["\n\n"], StringSplitOptions.RemoveEmptyEntries)
//        .Select(p => p.Trim())
//        .Where(p => !string.IsNullOrWhiteSpace(p))];
//}

//private static List<string> SplitWords(string text)
//{
//    return [.. text.Split((char[])null!, StringSplitOptions.RemoveEmptyEntries)];
//}

//private static string JoinWords(List<string> words, int startInclusive, int endExclusive)
//{
//    return string.Join(" ", words.GetRange(startInclusive, endExclusive - startInclusive));
//}
//}
