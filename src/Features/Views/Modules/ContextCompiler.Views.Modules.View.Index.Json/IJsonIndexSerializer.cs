namespace ContextCompiler.Views.Modules.View.Index.Json
{
    internal interface IJsonIndexSerializer
    {
        string Serialize(JsonIndex index);

        JsonIndex Deserialize(string value);
    }
}
