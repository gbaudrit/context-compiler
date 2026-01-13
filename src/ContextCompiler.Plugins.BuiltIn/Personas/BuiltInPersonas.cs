using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Plugins;
using ContextCompiler.Abstractions.ReasoningIR;

namespace ContextCompiler.Plugins.BuiltIn.Personas;

public sealed class DevArchitectPersona(IPersonaResultBuilder personaResultBuilder) : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.dev_architect", PluginKinds.Persona, priority: 10);
    public string PersonaId => "dev_architect";

    public Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var language = inputs?.TryGetValue("language", out var l) == true ? l?.ToString() ?? "fr" : "fr";
        var style = inputs?.TryGetValue("style", out var s) == true ? s?.ToString() ?? "direct" : "direct";
        var md = "" +
        $"## Persona: Architecte .NET senior ({language}) (id: {PersonaId})\n\n" +
        $"- Rôle: guider la conception et la qualité\n" +
        $"- Style: {style}\n" +
        "- Exigences: DI, SOLID, testabilité, sécurité\n" +
        "- Sortie: Markdown avec sections fixes\n\n" +
        "### Exigences globales\n\n" +
        "- Respecter les invariants\n" +
        "- Code déterministe et testable\n";
        var res = personaResultBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle("Dev Architect Persona")
            .WithFramingMarkdown(md)
            .WithMetadata(new Dictionary<string, string> { { "language", language }, { "style", style } })
            .WithRole("Architecte .NET senior")
            .WithMust(["DI", "SOLID", "testabilité", "sécurité", "Respecter les invariants", "Code déterministe et testable"])
            .WithMustNot(Array.Empty<string>())
            .Build();
        return Task.FromResult(res);
    }
}

public sealed class SecurityReviewerPersona(IPersonaResultBuilder personaResultBuilder) : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.security_reviewer", PluginKinds.Persona, priority: 10);
    public string PersonaId => "security_reviewer";

    public Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var severity = inputs?.TryGetValue("severityBias", out var b) == true ? b?.ToString() ?? "high" : "high";
        var md = "" +
        $"## Persona: Security Reviewer (id: {PersonaId})\n\n" +
        "- Rôle: reviewer sécurité\n" +
        $"- Bias: {severity}\n" +
        "### Engagements — MUST\n\n" +
        "- Lister risques\n" +
        "- Lister vulnérabilités\n" +
        "- Lister les secrets\n"+
        "- Vérifier les versions des dépendances\n" +
        "- Proposer recommandations\n" +
        "- Sortie: checklist + recommandations\n\n" +
        "### Checklist\n\n" +
        "- [ ] Secrets exposés\n- [ ] Injection\n- [ ] Permissions, ...\n";
        var res = personaResultBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle("Security Reviewer Persona")
            .WithFramingMarkdown(md)
            .WithMetadata(new Dictionary<string, string> { { "severityBias", severity } })
            .WithRole("Security Reviewer")
            .WithMust(["Lister risques", "Lister vulnérabilités", "Lister les secrets", "Vérifier les versions des dépendances", "Proposer recommandations"])
            .WithMustNot(Array.Empty<string>())
            .Build();
        return Task.FromResult(res);
    }
}

public sealed class DeepSecurityReviewerPersona(IPersonaResultBuilder personaResultBuilder) : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.deep_security_reviewer", PluginKinds.Persona, priority: 10);
    public string PersonaId => "deep_security_reviewer";

    public Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var severity = inputs?.TryGetValue("severityBias", out var b) == true ? b?.ToString() ?? "high" : "high";
        var md = "" +
        $"## Persona: Deep Security Reviewer (id: {PersonaId})\n\n" +
        "- Rôle: reviewer sécurité en profondeur\n" +
        $"- Bias: {severity}\n" +
        "### Engagements — MUST\n\n" +
        "- Respecter les engagements du Security Reviewer (security_reviewer)\n\n" +
        "- Analyser en profondeur le code\n";
        var res = personaResultBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle("Security Reviewer Persona")
            .WithFramingMarkdown(md)
            .WithMetadata(new Dictionary<string, string> { { "severityBias", severity } })
            .WithRole("Reviewer sécurité en profondeur")
            .WithMust(["Respecter les engagements du Security Reviewer (security_reviewer)", "Analyser en profondeur le code"])
            .WithMustNot(Array.Empty<string>())
            .Build();
        return Task.FromResult(res);
    }
}

public sealed class BusinessAnalystPersona(IPersonaResultBuilder personaResultBuilder) : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.business_analyst", PluginKinds.Persona, priority: 10);
    public string PersonaId => "business_analyst";

    public Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var domain = inputs?.TryGetValue("domain", out var d) == true ? d?.ToString() ?? "general" : "general";
        var audience = inputs?.TryGetValue("audience", out var a) == true ? a?.ToString() ?? "stakeholders" : "stakeholders";
        var format = inputs?.TryGetValue("format", out var f) == true ? f?.ToString() ?? "markdown" : "markdown";
        var md = "" +
        "## Persona: Business Analyst (id: {PersonaId})\n\n" +
        $"- Domaine: {domain}\n" +
        $"- Audience: {audience}\n" +
        "- Objectif: clarifier besoins, contraintes, et KPI\n\n" +
        "### Cadre d'analyse\n\n" +
        "- Contexte métier\n- Problème à résoudre\n- Parties prenantes\n- KPI / Impact attendu\n- Contraintes / Risques\n";
        var res = personaResultBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle("Business Analyst Persona")
            .WithFramingMarkdown(md)
            .WithMetadata(new Dictionary<string, string> { { "domain", domain }, { "audience", audience }, { "format", format } })
            .WithRole("Analyste métier")
            .WithMust(["Clarifier les besoins et contraintes"])
            .WithMustNot(Array.Empty<string>())
            .Build();
        return Task.FromResult(res);
    }
}

public sealed class DevSeniorPersona(IPersonaResultBuilder personaResultBuilder) : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.dev_senior", PluginKinds.Persona, priority: 10);
    public string PersonaId => "dev_senior";

    public Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var language = inputs?.TryGetValue("language", out var l) == true ? l?.ToString() ?? "fr" : "fr";
        var style = inputs?.TryGetValue("style", out var s) == true ? s?.ToString() ?? "direct" : "direct";
        var focus = inputs?.TryGetValue("focus", out var f) == true ? f?.ToString() ?? "quality" : "quality";
        var md = "" +
        $"## Persona: Développeur Senior ({language}) (id: {PersonaId})\n\n" +
        $"- Style: {style}\n" +
        $"- Focus: {focus}\n" +
        "- Bonnes pratiques: tests, lisibilité, performance, sécurité, DI\n\n" +
        "### Engagements — MUST\n\n" +
        "- Respect des conventions de code\n- Respect des conventions de nommage\n- Respect du typage\n- Couverture de tests adéquate\n- Gestion des erreurs robuste\n- Simplicité et maintenabilité\n- Commentaires dans le code\n";
        var res = personaResultBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle("Dev Senior Persona")
            .WithFramingMarkdown(md)
            .WithMetadata(new Dictionary<string, string> { { "language", language }, { "style", style }, { "focus", focus } })
            .WithRole("Développeur Senior")
            .WithMust(
            [
                "Respecter les bonnes pratiques de tests, lisibilité, performance, sécurité, DI",
                "Respect des conventions de code",
                "Respect des conventions de nommage",
                "Respect du typage",
                "Couverture de tests adéquate",
                "Gestion des erreurs robuste",
                "Simplicité et maintenabilité",
                "Commentaires dans le code"
            ])
            .WithMustNot(Array.Empty<string>())
            .Build();
        return Task.FromResult(res);
    }
}

public sealed class DevBadPersona(IPersonaResultBuilder personaResultBuilder) : IPersonaPlugin
{
    public PluginMetadata Metadata => BuiltInMetadata.Meta("builtin.persona.dev_bad", PluginKinds.Persona, priority: 10);
    public string PersonaId => "dev_bad";

    public Task<IPersonaResult> BuildAsync(PersonaContext ctx, CancellationToken ct)
    {
        var inputs = ctx.Inputs as IReadOnlyDictionary<string, object>;
        var language = inputs?.TryGetValue("language", out var l) == true ? l?.ToString() ?? "fr" : "fr";
        var style = inputs?.TryGetValue("style", out var s) == true ? s?.ToString() ?? "direct" : "direct";
        var focus = inputs?.TryGetValue("focus", out var f) == true ? f?.ToString() ?? "bad quality" : "bad quality";
        var md = "" +
        $"## Persona: Développeur mauvais ({language}) (id: {PersonaId})\n\n" +
        $"- Style: {style}\n" +
        $"- Focus: {focus}\n" +
        "- Mauvaises pratiques: code illisible, manque de tests, mauvaise gestion des erreurs\n\n" +
        "### Engagements — MUST\n\n" +
        "- Ne respecte pas les conventions de code\n- Ne respecte pas les conventions de nommage\n- Ne respecte pas le typage\n- Mauvaise gestion d'erreurs\n- Compléxité et défaut de maintenabilité\n";
        var res = personaResultBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle("Dev Bad Persona")
            .WithFramingMarkdown(md)
            .WithMetadata(new Dictionary<string, string> { { "language", language }, { "style", style }, { "focus", focus } })
            .WithRole("Développeur mauvais")
            .WithMust(
            [
                "Ne pas respecter les bonnes pratiques de tests, lisibilité, performance, sécurité, DI",
                "Ne pas respecter les conventions de code",
                "Ne pas respecter les conventions de nommage",
                "Ne pas respecter le typage",
                "Ne pas gérer les erreurs",
                "Ne pas assurer la simplicité et la maintenabilité",
                "Ne pas commenter le code"
            ])
            .WithMustNot(Array.Empty<string>())
            .Build();
        return Task.FromResult(res);
    }
}
