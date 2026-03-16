using System.Text;

using ContextCompiler.Modules.Rag.Abstractions;
using ContextCompiler.Modules.Rag.Models;

namespace ContextCompiler.Modules.Rag.Tokenizers;

internal sealed class TokenChunker(ITokenizer tokenizer) : ITokenChunker
{
    public async Task<IReadOnlyList<string>> SplitChunksByToken(
        string text,
        int maxTokens = 512,
        int overlapTokens = 64,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return [];
        }

        if (maxTokens > 0)
        {
            if (overlapTokens < 0 || overlapTokens >= maxTokens)
            {
                throw new ArgumentOutOfRangeException(nameof(overlapTokens));
            }

            // Normalisation légère
            text = NormalizeText(text);

            // 1) On commence par des paragraphes
            List<string> paragraphs = SplitParagraphs(text);

            List<string> chunks = [];
            StringBuilder currentChunk = new();

            foreach (string paragraph in paragraphs)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Si le paragraphe rentre seul, on essaie de l'ajouter au chunk courant
                if (await CountTokensAsync(paragraph, tokenizer) <= maxTokens)
                {
                    string candidate = currentChunk.Length == 0
                        ? paragraph
                        : currentChunk.ToString() + Environment.NewLine + Environment.NewLine + paragraph;

                    if (await CountTokensAsync(candidate, tokenizer) <= maxTokens)
                    {
                        if (currentChunk.Length > 0)
                        {
                            _ = currentChunk.AppendLine().AppendLine();
                        }

                        _ = currentChunk.Append(paragraph);
                    }
                    else
                    {
                        // Flush du chunk courant
                        if (currentChunk.Length > 0)
                        {
                            chunks.Add(currentChunk.ToString());
                        }

                        // Nouveau chunk avec overlap depuis le précédent
                        string overlapText = chunks.Count > 0
                            ? await BuildOverlapTextAsync(chunks[^1], tokenizer, overlapTokens)
                            : string.Empty;

                        _ = currentChunk.Clear();

                        if (!string.IsNullOrWhiteSpace(overlapText))
                        {
                            _ = currentChunk.Append(overlapText);

                            string withParagraph = currentChunk.ToString() + Environment.NewLine + Environment.NewLine + paragraph;
                            if (await CountTokensAsync(withParagraph, tokenizer) <= maxTokens)
                            {
                                _ = currentChunk.AppendLine().AppendLine().Append(paragraph);
                            }
                            else
                            {
                                _ = currentChunk.Clear();
                                _ = currentChunk.Append(paragraph);
                            }
                        }
                        else
                        {
                            _ = currentChunk.Append(paragraph);
                        }
                    }
                }
                else
                {
                    // Paragraphe trop gros : on flush le chunk courant d'abord
                    if (currentChunk.Length > 0)
                    {
                        chunks.Add(currentChunk.ToString());
                        _ = currentChunk.Clear();
                    }

                    // Puis on split ce paragraphe en sous-chunks
                    List<string> subChunks = await SplitLargeBlockByWords(
                        paragraph,
                        tokenizer,
                        maxTokens,
                        overlapTokens,
                        cancellationToken);

                    chunks.AddRange(subChunks);
                }
            }

            if (currentChunk.Length > 0)
            {
                chunks.Add(currentChunk.ToString());
            }

            return chunks;
        }

        throw new ArgumentOutOfRangeException(nameof(maxTokens));
    }

    private static async Task<List<string>> SplitLargeBlockByWords(
        string text,
        ITokenizer tokenizer,
        int maxTokens,
        int overlapTokens,
        CancellationToken cancellationToken)
    {
        List<string> words = SplitWords(text);
        List<string> chunks = [];

        int start = 0;

        while (start < words.Count)
        {
            cancellationToken.ThrowIfCancellationRequested();

            int bestEnd = await FindLargestFittingWordRange(words, start, tokenizer, maxTokens);

            if (bestEnd <= start)
            {
                // Sécurité : si même un seul mot "ne passe pas",
                // on force l'avance pour éviter une boucle infinie
                bestEnd = start + 1;
            }

            string chunk = JoinWords(words, start, bestEnd);
            chunks.Add(chunk);

            if (bestEnd >= words.Count)
            {
                break;
            }

            // Calcul du nouveau start avec overlap en tokens
            int overlapStart = await FindOverlapStartByTokenBudget(
                words,
                start,
                bestEnd,
                tokenizer,
                overlapTokens);

            start = overlapStart < bestEnd ? overlapStart : bestEnd;
        }

        return chunks;
    }

    private static async Task<int> FindLargestFittingWordRange(
        List<string> words,
        int start,
        ITokenizer tokenizer,
        int maxTokens)
    {
        int low = start + 1;
        int high = words.Count;
        int best = start + 1;

        while (low <= high)
        {
            int mid = low + ((high - low) / 2);
            string candidate = JoinWords(words, start, mid);
            int tokenCount = await CountTokensAsync(candidate, tokenizer);

            if (tokenCount <= maxTokens)
            {
                best = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return best;
    }

    private static async Task<int> FindOverlapStartByTokenBudget(
        List<string> words,
        int chunkStart,
        int chunkEnd,
        ITokenizer tokenizer,
        int overlapTokens)
    {
        if (overlapTokens <= 0)
        {
            return chunkEnd;
        }

        int start = chunkEnd - 1;
        int bestStart = chunkEnd;

        while (start >= chunkStart)
        {
            string candidate = JoinWords(words, start, chunkEnd);
            int tokens = await CountTokensAsync(candidate, tokenizer);

            if (tokens > overlapTokens)
            {
                break;
            }

            bestStart = start;
            start--;
        }

        return bestStart;
    }

    private static async Task<string> BuildOverlapTextAsync(
        string previousChunk,
        ITokenizer tokenizer,
        int overlapTokens)
    {
        if (string.IsNullOrWhiteSpace(previousChunk) || overlapTokens <= 0)
        {
            return string.Empty;
        }

        List<string> words = SplitWords(previousChunk);
        int start = words.Count - 1;
        int bestStart = words.Count;

        while (start >= 0)
        {
            string candidate = JoinWords(words, start, words.Count);
            int tokenCount = await CountTokensAsync(candidate, tokenizer);

            if (tokenCount > overlapTokens)
            {
                break;
            }

            bestStart = start;
            start--;
        }

        return bestStart < words.Count
            ? JoinWords(words, bestStart, words.Count)
            : string.Empty;
    }

    private static async Task<int> CountTokensAsync(string text, ITokenizer tokenizer)
    {
        TokenizedText encoded = await tokenizer.Encode(text);
        return encoded.InputIds.Length;
    }

    private static string NormalizeText(string text)
    {
        return text
            .Replace("\r\n", "\n")
            .Replace('\r', '\n')
            .Trim();
    }

    private static List<string> SplitParagraphs(string text)
    {
        return [.. text
            .Split(["\n\n"], StringSplitOptions.RemoveEmptyEntries)
            .Select(p => p.Trim())
            .Where(p => !string.IsNullOrWhiteSpace(p))];
    }

    private static List<string> SplitWords(string text)
    {
        return [.. text.Split((char[])null!, StringSplitOptions.RemoveEmptyEntries)];
    }

    private static string JoinWords(List<string> words, int startInclusive, int endExclusive)
    {
        return string.Join(" ", words.GetRange(startInclusive, endExclusive - startInclusive));
    }
}
