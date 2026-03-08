namespace ContextCompiler.Abstractions.Pipelines
{
    public class PipelineAbortedException : Exception
    {

        public PipelineAbortedException(string message) : base(message)
        {
        }
        public PipelineAbortedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
