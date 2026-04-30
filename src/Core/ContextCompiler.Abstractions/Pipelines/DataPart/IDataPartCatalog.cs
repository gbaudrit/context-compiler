namespace ContextCompiler.Abstractions.Pipelines.DataPart
{
    public interface IDataPartCatalog
    {
        IDataPartDescriptor GetDescriptor(DataPartType type);
    }
}
