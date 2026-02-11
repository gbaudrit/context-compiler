namespace ContextCompiler.Host.Cli.Handlers
{
    internal sealed class NewProject : ICtxcNewProjectHandler
    {
        public Task<int> HandleAsync(string path)
        {
            string fullPath = Path.Combine(path, "ctxc.config.json");
            if (File.Exists(fullPath))
            {
                Console.WriteLine($"A ctxc.config.json already exists at {fullPath}. Aborting.");
                return Task.FromResult(1);
            }

            File.WriteAllText(fullPath, /*lang=json,strict*/ @"{
                ""context"": {
                    ""enabled"": true,
                    ""name"": """",
                    ""summary"": """",
                    ""domain"": """",
                    ""audiences"": {},
                    ""objectives"": [],
                    ""assumptions"": [],
                    ""constraints"": {
                      ""canUseExternalSources"": false,
                      ""must"": [],
                      ""mustNot"": []
                    },
                    ""glossary"": {}
                },
                ""personas"": {},
                ""files"": [],
                ""views"": {
                    ""inline"":false,
                    ""views"":[]
                }
            }");
            return Task.FromResult(0);
        }
    }
}
