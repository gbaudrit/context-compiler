namespace ContextCompiler.Abstractions.Configuration
{
    public interface ISchemaBuilder
    {
        ISchema Build();
        ISchemaBuilder InitNew();
        ISchemaBuilder WithContent(string content);
        ISchemaBuilder WithName(string name);
        ISchemaBuilder WithPath(string path);
    }
}
