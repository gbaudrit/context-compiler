using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

using ContextCompiler.Modules.Abstractions;

namespace ContextCompiler.Modules.Loader
{
    internal sealed partial class ModuleRestoreVersionNpmLikeParser(IModuleRestoreVersionBuilder moduleRestoreVersionBuilder) : IModuleRestoreVersionParser
    {
        public bool TryParse(string version, [NotNullWhen(true)] out IModuleRestoreVersion? moduleRestoreVersion)
        {
            moduleRestoreVersion = null;

            if (string.IsNullOrWhiteSpace(version))
            {
                return false;
            }

            version = version.Trim();

            try
            {
                // Handle exact version (e.g., "1.2.3")
                if (ExactVersionRegex().IsMatch(version))
                {
                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin(version)
                                                                     .WithMax(version)
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.Exactly)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.Exactly)
                                                                     .Build();
                    return true;
                }

                if (string.Equals(version, "*", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(version, "latest", StringComparison.OrdinalIgnoreCase))
                {
                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin("0.0.0")
                                                                     .WithMax("*")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.Unbounded)
                                                                     .Build();
                    return true;
                }

                // Handle prefix wildcard patterns (e.g., "0.1.0-alpha.*")
                if (version.Contains('*', StringComparison.Ordinal) || version.EndsWith(".x", StringComparison.OrdinalIgnoreCase))
                {
                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin("0.0.0")
                                                                     .WithMax("*")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.Unbounded)
                                                                     .Build();
                    return true;
                }

                // Handle tilde range (e.g., "~1.2.3" -> allows patch-level changes: >=1.2.3 <1.3.0)
                Match tildeMatch = TildeRangeRegex().Match(version);
                if (tildeMatch.Success)
                {
                    string major = tildeMatch.Groups[1].Value;
                    string minor = tildeMatch.Groups[2].Value;
                    string patch = tildeMatch.Groups[3].Value;
                    int nextMinor = int.Parse(minor, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture) + 1;

                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin($"{major}.{minor}.{patch}")
                                                                     .WithMax($"{major}.{nextMinor}.0")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThan)
                                                                     .Build();
                    return true;
                }

                // Handle caret range (e.g., "^1.2.3" -> allows minor-level changes: >=1.2.3 <2.0.0)
                Match caretMatch = CaretRangeRegex().Match(version);
                if (caretMatch.Success)
                {
                    string major = caretMatch.Groups[1].Value;
                    string minor = caretMatch.Groups[2].Value;
                    string patch = caretMatch.Groups[3].Value;
                    int nextMajor = int.Parse(major, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture) + 1;

                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin($"{major}.{minor}.{patch}")
                                                                     .WithMax($"{nextMajor}.0.0")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThan)
                                                                     .Build();
                    return true;
                }

                // Handle wildcard patterns (e.g., "1.2.*" or "1.2.x")
                Match wildcardMatch = WildcardRangeRegex().Match(version);
                if (wildcardMatch.Success)
                {
                    string major = wildcardMatch.Groups[1].Value;
                    string minor = wildcardMatch.Groups[2].Value;
                    int nextMinor = int.Parse(minor, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture) + 1;

                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin($"{major}.{minor}.0")
                                                                     .WithMax($"{major}.{nextMinor}.0")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThan)
                                                                     .Build();
                    return true;
                }

                // Handle >= operator (e.g., ">=1.2.3")
                Match greaterOrEqualMatch = GreaterOrEqualRangeRegex().Match(version);
                if (greaterOrEqualMatch.Success)
                {
                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin(greaterOrEqualMatch.Groups[1].Value)
                                                                     .WithMax("*")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.Unbounded)
                                                                     .Build();
                    return true;
                }

                // Handle > operator (e.g., ">1.2.3")
                Match greaterMatch = GreaterRangeRegex().Match(version);
                if (greaterMatch.Success)
                {
                    string major = greaterMatch.Groups[1].Value;
                    string minor = greaterMatch.Groups[2].Value;
                    int patch = int.Parse(greaterMatch.Groups[3].Value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture) + 1;

                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin($"{major}.{minor}.{patch}")
                                                                     .WithMax("*")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThan)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.Unbounded)
                                                                     .Build();
                    return true;
                }

                // Handle <= operator (e.g., "<=1.2.3")
                Match lessOrEqualMatch = LessOrEqualRangeRegex().Match(version);
                if (lessOrEqualMatch.Success)
                {
                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin("0.0.0")
                                                                     .WithMax(lessOrEqualMatch.Groups[1].Value)
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThanOrEqual)
                                                                     .Build();
                    return true;
                }

                // Handle < operator (e.g., "<1.2.3")
                Match lessMatch = LessRangeRegex().Match(version);
                if (lessMatch.Success)
                {
                    string major = lessMatch.Groups[1].Value;
                    string minor = lessMatch.Groups[2].Value;
                    int patch = int.Parse(lessMatch.Groups[3].Value, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture);

                    if (patch > 0)
                    {
                        patch--;
                        moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin("0.0.0")
                                                                     .WithMax($"{major}.{minor}.{patch}")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThan)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThanOrEqual)
                                                                     .Build();
                    }
                    else if (int.Parse(minor, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture) > 0)
                    {
                        int prevMinor = int.Parse(minor, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture) - 1;
                        moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin("0.0.0")
                                                                     .WithMax($"{major}.{prevMinor}.9999")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThan)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThanOrEqual)
                                                                     .Build();
                    }
                    else
                    {
                        moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin("0.0.0")
                                                                     .WithMax($"{major}.{minor}.{patch}")
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThan)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThanOrEqual)
                                                                     .Build();
                    }
                    return true;
                }

                // Handle range with space (e.g., ">=1.2.3 <2.0.0")
                Match rangeMatch = RangeWithSpaceRegex().Match(version);
                if (rangeMatch.Success)
                {
                    moduleRestoreVersion = moduleRestoreVersionBuilder.InitNew()
                                                                     .WithRaw(version)
                                                                     .WithMin(rangeMatch.Groups[1].Value)
                                                                     .WithMax(rangeMatch.Groups[2].Value)
                                                                     .WithMinBoundOperator(IModuleRestoreVersion.BoundOperator.GreaterThanOrEqual)
                                                                     .WithMaxBoundOperator(IModuleRestoreVersion.BoundOperator.LessThan)
                                                                     .Build();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        [GeneratedRegex(@"^\d+\.\d+\.\d+(-[a-zA-Z0-9\.]+)?$")]
        private static partial Regex ExactVersionRegex();
        [GeneratedRegex(@"^~(\d+)\.(\d+)\.(\d+)$")]
        private static partial Regex TildeRangeRegex();
        [GeneratedRegex(@"^\^(\d+)\.(\d+)\.(\d+)$")]
        private static partial Regex CaretRangeRegex();
        [GeneratedRegex(@"^(\d+)\.(\d+)\.[*x]$")]
        private static partial Regex WildcardRangeRegex();
        [GeneratedRegex(@"^>=(\d+\.\d+\.\d+)$")]
        private static partial Regex GreaterOrEqualRangeRegex();
        [GeneratedRegex(@"^>(\d+)\.(\d+)\.(\d+)$")]
        private static partial Regex GreaterRangeRegex();
        [GeneratedRegex(@"^<=(\d+\.\d+\.\d+)$")]
        private static partial Regex LessOrEqualRangeRegex();
        [GeneratedRegex(@"^<(\d+)\.(\d+)\.(\d+)$")]
        private static partial Regex LessRangeRegex();
        [GeneratedRegex(@"^>=(\d+\.\d+\.\d+)\s+<(\d+\.\d+\.\d+)$")]
        private static partial Regex RangeWithSpaceRegex();
    }
}
