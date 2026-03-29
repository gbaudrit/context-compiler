namespace ContextCompiler.Abstractions.Pipelines.Document
{
    public enum DocumentStage
    {
        StartProcess = 0,
        Discovery = 10,
        ReadScopeGuards = 20,
        FileRead = 30,
        DataRead = 40,
        DataPart = 50,
        Engineering = 60,
        Fragment = 70,
        ContentGuards = 80,
        TranscodeFragment = 90,
        EvidenceAssign = 100,
        Preflight = 110,
        EndProcess = 9999,
    }
}
