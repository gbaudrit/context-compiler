using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.BuiltIn.Personas;

public sealed class DevArchitectPersona : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.dev_architect", PluginKinds.Persona, priority: 10);
    public string PersonaId => "dev_architect";

    public Task<PersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var language = inputs?.TryGetValue("language", out var l) == true ? l?.ToString() ?? "fr" : "fr";
        var style = inputs?.TryGetValue("style", out var s) == true ? s?.ToString() ?? "direct" : "direct";
        var md = "" +
        $"## Persona: Architecte .NET senior ({language})\n\n" +
        $"- Rôle: guider la conception et la qualité\n" +
        $"- Style: {style}\n" +
        "- Exigences: DI, SOLID, testabilité, sécurité\n" +
        "- Sortie: Markdown avec sections fixes\n\n" +
        "### Exigences globales\n\n" +
        "- Respecter les invariants\n" +
        "- Code déterministe et testable\n";
        var res = new PersonaResult(PersonaId, "Dev Architect Persona", md, new Dictionary<string,string>{{"language",language},{"style",style}});
        return Task.FromResult(res);
    }
}

public sealed class SecurityReviewerPersona : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.security_reviewer", PluginKinds.Persona, priority: 10);
    public string PersonaId => "security_reviewer";

    public Task<PersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var severity = inputs?.TryGetValue("severityBias", out var b) == true ? b?.ToString() ?? "high" : "high";
        var md = "" +
        "## Persona: Security Reviewer\n\n" +
        "- Rôle: reviewer sécurité\n" +
        $"- Bias: {severity}\n" +
        "- MUST: lister risques, secrets, injection\n" +
        "- Sortie: checklist + recommandations\n\n" +
        "### Checklist\n\n" +
        "- [ ] Secrets exposés\n- [ ] Injection\n- [ ] Permissions\n";
        var res = new PersonaResult(PersonaId, "Security Reviewer Persona", md, new Dictionary<string,string>{{"severityBias",severity}});
        return Task.FromResult(res);
    }
}

public sealed class BusinessAnalystPersona : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.business_analyst", PluginKinds.Persona, priority: 10);
    public string PersonaId => "business_analyst";

    public Task<PersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var domain = inputs?.TryGetValue("domain", out var d) == true ? d?.ToString() ?? "general" : "general";
        var audience = inputs?.TryGetValue("audience", out var a) == true ? a?.ToString() ?? "stakeholders" : "stakeholders";
        var format = inputs?.TryGetValue("format", out var f) == true ? f?.ToString() ?? "markdown" : "markdown";
        var md = "" +
        "## Persona: Business Analyst\n\n" +
        $"- Domaine: {domain}\n" +
        $"- Audience: {audience}\n" +
        "- Objectif: clarifier besoins, contraintes, et KPI\n\n" +
        "### Cadre d'analyse\n\n" +
        "- Contexte métier\n- Problème à résoudre\n- Parties prenantes\n- KPI / Impact attendu\n- Contraintes / Risques\n";
        var res = new PersonaResult(PersonaId, "Business Analyst Persona", md, new Dictionary<string,string>{{"domain",domain},{"audience",audience},{"format",format}});
        return Task.FromResult(res);
    }
}
