namespace ContextCompiler.Modules;

internal static class ModulePackageKeys
{
    public static string WithSource(string packageId, string sourceId)
    {
        return string.Equals(sourceId, ModuleSourceIds.Default, StringComparison.OrdinalIgnoreCase)
            ? packageId
            : $"{packageId}@{sourceId}";
    }

}
