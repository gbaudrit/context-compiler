namespace ContextCompiler.Abstractions.Views;


public sealed record ViewDefinition(
    string ViewId,
    string Title,
    ViewSelectRules Select,
    ViewOrderRules Order,
    ViewFormatRules Format
);

public sealed record ViewSelectRules(
    IReadOnlyList<string> Include,   // e.g. ["concern:security", "risk:*"]
    IReadOnlyList<string> Exclude    // e.g. ["policy:blocked"]
);

public sealed record ViewOrderRules(
    // Supported stable keys (extend later, but keep deterministic)
    bool RiskSeverityDesc = true,
    bool ThenBySourcePath = true,
    bool ThenByLocator = true,
    bool ThenByEvidenceKey = true
);

public sealed record ViewFormatRules(
    bool IncludeFragmentContent = true,
    int? MaxContentChars = null
);
