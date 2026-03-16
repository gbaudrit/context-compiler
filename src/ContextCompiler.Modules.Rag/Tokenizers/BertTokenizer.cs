using ContextCompiler.Modules.Rag.Abstractions;

using FastBertTokenizerImpl = FastBertTokenizer.BertTokenizer;

namespace ContextCompiler.Modules.Rag.Tokenizers
{
    internal class BertTokenizer : ITokenizer
    {

        private readonly FastBertTokenizerImpl _bertTokenizer;

        public BertTokenizer()
        {
            _bertTokenizer = new();
            using StreamReader vocabTxtFile = new(GetFullPathToModelFile("default", "vocab.txt"));
            _bertTokenizer.LoadVocabulary(vocabTxtFile, true);

        }

        private static string GetFullPathToModelFile(string modelName, string fileName)
        {
            string text = Path.Combine(AppContext.BaseDirectory, "LocalEmbeddingsModel", modelName, fileName);
            return !File.Exists(text) ? throw new InvalidOperationException("Required file " + text + " does not exist") : text;
        }

        public Task Encode(string text)
        {
            _bertTokenizer.Encode(text);
        }

    }
}
