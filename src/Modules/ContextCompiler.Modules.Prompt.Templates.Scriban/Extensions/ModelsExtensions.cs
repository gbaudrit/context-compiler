using ContextCompiler.Abstractions.Output;
using ContextCompiler.Abstractions.Personas;
using ContextCompiler.Abstractions.Prompt;
using ContextCompiler.Abstractions.Rendering;

namespace ContextCompiler.Modules.Prompt.Templates.Scriban.Extensions
{
    internal static class ModelsExtensions
    {

        public static IRenderable ToRenderable(this IPrompt o)
        {
            return new Renderable()
            {
                Subject = new
                {
                    name = o.Name,
                    summary = o.Summary,
                    domain = o.Domain,
                    audiences = o.Audiences,
                    objectives = o.Objectives,
                    assumptions = o.Assumptions,
                    personas = o.Personas.Select(x => x.ToTemplateModel()).ToList(),
                    must = o.MustConstraints.Select(x => x.ToTemplateModel()).ToList(),
                    mustNot = o.MustNotConstraints.Select(x => x.ToTemplateModel()).ToList(),
                    glossary = o.Glossary.Select(x => x.ToTemplateModel()).ToList(),
                    commands = o.Commands.GroupBy(x => x.PersonaId).ToDictionary(g => g.Key, g => g.Select(x => x.ToTemplateModel()).ToList()),
                    artifacts = o.Artifacts.Select(x => x.ToTemplateModel()).ToList(),
                    blueprints = o.Blueprints.Select(x => x.ToTemplateModel()).ToList(),
                }
            };
        }

        public static object ToTemplateModel(this IPersona o)
        {
            return new
            {
                id = o.PersonaId,
                title = o.Title,
                role = o.Role,
                framingMarkdown = o.FramingMarkdown,
                metadata = o.Metadata ?? new Dictionary<string, string>(),
                must = o.Must.Select(m => m.ToTemplateModel()).ToList(),
                mustNot = o.MustNot.Select(mn => mn.ToTemplateModel()).ToList()
            };
        }

        public static object ToTemplateModel(this IBlueprint o)
        {
            return new
            {
                id = o.Id,
                name = o.Name,
                description = o.Description,
                mustConstraints = o.MustConstraints.Select(m => m.ToTemplateModel()).ToList(),
                mustNotConstraints = o.MustNotConstraints.Select(mn => mn.ToTemplateModel()).ToList(),
                objectives = o.Objectives.Select(obj => obj.ToTemplateModel()).ToList(),
                assumptions = o.Assumptions.Select(a => a.ToTemplateModel()).ToList(),
                glossary = o.Glossary.Select(g => g.ToTemplateModel()).ToList(),
                commands = o.Commands.Select(c => c.ToTemplateModel()).ToList(),
                steps = o.Steps.Select(s => s.ToTemplateModel()).ToList()
            };
        }

        public static object ToTemplateModel(this IBlueprintStep o)
        {
            return new
            {
                title = o.Title,
                description = o.Description,
                expectedOutcome = o.ExpectedOutcome,
                content = o.Content,
                mustConstraints = o.MustConstraints.Select(m => m.ToTemplateModel()).ToList(),
                mustNotConstraints = o.MustNotConstraints.Select(mn => mn.ToTemplateModel()).ToList()
            };
        }

        public static object ToTemplateModel(this IObjective o)
        {
            return new
            {
                id = o.Id,
                name = o.Name,
                description = o.Description,
                rationale = o.Rationale
            };
        }

        public static object ToTemplateModel(this IAssumption o)
        {
            return new
            {
                id = o.Id,
                name = o.Name,
                description = o.Description,
                rationale = o.Rationale
            };
        }

        public static object ToTemplateModel(this IMustConstraint o)
        {
            return new
            {
                id = o.Id,
                rationale = o.Rationale,
                text = o.Text
            };
        }

        public static object ToTemplateModel(this IMustNotConstraint o)
        {
            return new
            {
                id = o.Id,
                rationale = o.Rationale,
                text = o.Text
            };
        }

        public static object ToTemplateModel(this IGlossaryTerm o)
        {
            return new
            {
                term = o.Term,
                definition = o.Definition
            };
        }

        public static object ToTemplateModel(this ICommand o)
        {
            return new
            {
                name = o.Id,
                description = o.Description,
                example = o.Example
            };
        }

        public static object ToTemplateModel(this IOutputArtifact o)
        {
            return new
            {
                filename = o.FileName,
                description = o.Description
            };
        }

    }
}
