namespace ContextCompiler.Cli.Handlers
{
    internal sealed class NewProjectHandler : ICtxcNewProjectHandler
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
    ""$schema"": ""https://raw.githubusercontent.com/gbaudrit/context-compiler/refs/heads/main/schemas/v0.0.1/ctxc.config.schema.json"",
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
    ""personas"": {
        ""active"": [],
        ""mode"": ""append""
    },
    ""files"": [
        {
            ""includes"": [""*""]
        }
    ],
    ""views"": {
        ""inline"":false,
        ""views"":[]
    }
}"
            );
            return Task.FromResult(0);
        }
    }
}
