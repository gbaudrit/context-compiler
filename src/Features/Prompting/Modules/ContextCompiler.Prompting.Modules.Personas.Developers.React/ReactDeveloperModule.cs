using ContextCompiler.Abstractions.Configuration;
using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Modules.Abstractions.CompilePipeline;
using ContextCompiler.Abstractions.Common;

using Microsoft.Extensions.Logging;
using ContextCompiler.Prompting.Abstractions.Personas;
using ContextCompiler.Prompting.Abstractions.Commands;
using ContextCompiler.Prompting.Abstractions.Prompt;
using ContextCompiler.Abstractions.Pipelines.Compile;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Prompting.Modules.Personas.Developers.React;

public sealed class ReactDeveloperModule(
    IConfigProvider cfgProvider,
    IPersonasProvider personasProvider,
    IPersonaBuilder personaBuilder,
    ICommandsProvider commandsProvider,
    ICommandBuilder commandBuilder,
    ILogger<ReactDeveloperModule> logger) : IConfigurationModule
{
    private const string PersonaId = "developers.react";

    public ModuleMetadata Metadata => ICompilePipelineModule.Meta($"personas.{PersonaId}", CompilePipelineModuleKinds.Setup, priority: 10);

    public Task<IResult<ICompilePipelineRunResult>> Run(ICompilePipelineRunContext context, CancellationToken cancellationToken)
    {
        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("create-component")
                                    .WithDescription("Create a new React component with TypeScript")
                                    .ForPersona(PersonaId)
                                    .Build());

        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("create-hook")
                                    .WithDescription("Create a custom React hook")
                                    .ForPersona(PersonaId)
                                    .Build());

        commandsProvider.AddCommand(commandBuilder.InitNew()
                                    .WithName("write")
                                    .WithDescription("Write React code that responds to functional requirements")
                                    .ForPersona(PersonaId)
                                    .Build());

        BuildReactDeveloperPersona();

        return context.Success();
    }

    private void BuildReactDeveloperPersona()
    {
        string role = "React Developer";
        string language = "EN";

        personasProvider.Add(personaBuilder
            .InitNew()
            .WithPersonaId(PersonaId)
            .WithTitle(role)
            .WithMetadata(new Dictionary<string, string> { { "language", language } })
            .WithRole(role)
            .WithMust(
            [
                "Write React code using TypeScript for type safety.",
                "Use functional components with hooks instead of class components.",
                "Use .tsx extension for files containing JSX/TypeScript.",
                "Name components with PascalCase matching the filename (Button.tsx exports Button).",
                "Define TypeScript interfaces for all component props.",
                "Follow React Hooks rules: only call at top level, only in React functions.",
                "Use appropriate state management: local state (useState), context, or external library (Redux, Zustand).",
                "Organize code by feature: components/, pages/, hooks/, services/, types/, utils/.",
                "Abstract API calls in service layers, not directly in components.",
                "Implement error boundaries to catch and handle component errors gracefully.",
                "Use semantic HTML elements and ARIA attributes where appropriate.",
                "Always provide stable, unique keys for list items.",
                "Use environment variables for configuration (API URLs, feature flags).",
                "Implement code splitting with React.lazy() and Suspense for routes and heavy components.",
                "Use useCallback for functions passed as props to memoized children.",
                "Use useMemo for expensive computations.",
                "Wrap expensive components in React.memo() to prevent unnecessary re-renders.",
                "Name custom hooks with 'use' prefix (useAuth, useFetch, useForm).",
                "Compose custom hooks from built-in hooks (useState, useEffect, etc.).",
                "Return cleanup functions from useEffect for subscriptions and timers.",
                "Handle API errors consistently with user-friendly messages.",
                "Use toast/snackbar library for non-blocking error and success messages.",
                "Implement accessibility features following WCAG guidelines.",
                "Use semantic HTML elements (header, nav, main, article, button).",
                "Ensure all interactive elements are keyboard accessible with visible focus indicators.",
                "Write unit tests for components, hooks, and utility functions using React Testing Library.",
                "Mock API calls with MSW (Mock Service Worker) for realistic testing.",
                "Use React Testing Library for component testing (not Enzyme).",
                "Maintain >80% test coverage for components and hooks.",
                "Create .env files for each environment (.env.development, .env.production).",
                "Prefix React environment variables with REACT_APP_ or VITE_.",
                "Enable minification, tree-shaking, and source maps in production build.",
                "Integrate analytics, performance monitoring, and error tracking.",
                "Use Web Vitals API or library to track Core Web Vitals (LCP, FID, CLS).",
                "Set up CI/CD pipeline with GitHub Actions, GitLab CI, or similar.",
                "Optimize images, enable compression, and configure CDN for static assets."
            ])
            .WithMustNot(
            [
                "Do not create functions inline in JSX if passed as props - use useCallback.",
                "Never mutate state directly - always use setState or state updater functions.",
                "Do not use array indexes as keys unless list is static and never reordered.",
                "Do not put complex business logic in JSX - extract to functions or hooks.",
                "Do not ignore ESLint warnings about missing useEffect/useCallback dependencies.",
                "Avoid 'any' type in TypeScript - use specific types or generics.",
                "Do not leave console.log statements in production code.",
                "Do not create components larger than 300 lines - break into smaller components.",
                "Do not store sensitive tokens in component state or Context without encryption.",
                "Never commit .env files or secrets to version control.",
                "Do not use class components unless absolutely necessary for legacy code.",
                "Avoid using index as key when rendering lists that can change.",
                "Do not perform side effects directly in render - use useEffect.",
                "Avoid prop drilling - use Context API or state management library.",
                "Do not fetch data in useEffect without proper cleanup and abort controller.",
                "Avoid premature optimization - measure first, then optimize.",
                "Do not mix concerns - keep presentational and container components separate.",
                "Avoid importing entire libraries - use tree-shakable imports."
            ])
            .Build());
    }
}
