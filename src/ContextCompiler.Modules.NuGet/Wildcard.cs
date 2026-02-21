namespace ContextCompiler.Modules.NuGet;

public static class Wildcard
{
    public static bool IsMatch(string pattern, string value)
    {
        string p = "^" + System.Text.RegularExpressions.Regex.Escape(pattern).Replace("\\*", ".*").Replace("\\?", ".") + "$";
        return System.Text.RegularExpressions.Regex.IsMatch(value, p, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    }
}
