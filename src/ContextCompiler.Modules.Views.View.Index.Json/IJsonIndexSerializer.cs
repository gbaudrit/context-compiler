namespace ContextCompiler.Modules.Views.View.Index.Json
{
    internal interface IJsonIndexSerializer
    {
        string Serialize(JsonIndex index);

        JsonIndex Deserialize(string value);
    }
}
