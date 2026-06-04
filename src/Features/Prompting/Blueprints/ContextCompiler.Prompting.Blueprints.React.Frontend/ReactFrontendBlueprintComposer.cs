using ContextCompiler.Modules.Abstractions;
using ContextCompiler.Abstractions.Common;
using ContextCompiler.Prompting.Abstractions;
using ContextCompiler.Prompting.Abstractions.Prompt;
using ContextCompiler.Prompting.Abstractions.Pipelines.PromptComposition;
using ContextCompiler.Modules.Abstractions.Pipelines.Compile;

namespace ContextCompiler.Prompting.Blueprints.React.Frontend;

internal sealed class ReactFrontendBlueprintComposer(
    IPrompt prompt,
    IBlueprintBuilder blueprintBuilder,
    IBlueprintStepBuilder stepBuilder) : IBlueprintComposerModule
{
    public ModuleMetadata Metadata => ICompilePipelineModule.Meta("blueprints.react.frontend", CompilePipelineModuleKinds.OutputComposition, priority: 10);

    public async Task<IResult<IPromptComposerRunResult>> Run(IPromptComposerRunContext context, CancellationToken cancellationToken)
    {
        IBlueprint blueprint = blueprintBuilder
            .InitNew()
            .WithId("react.frontend")
            .WithName("React Frontend Application Development")
            .WithDescription("Comprehensive guide for building modern, production-ready React applications with TypeScript, component architecture, state management, routing, API integration, and industry best practices.")

            // OBJECTIVES
            .WithObjective(o => o
                .WithId("OBJ-REACT-1")
                .WithDescription("Build a maintainable React application with clear component architecture and separation of concerns")
                .WithRationale("Well-structured components and proper separation enable long-term maintainability and team collaboration"))
            .WithObjective(o => o
                .WithId("OBJ-REACT-2")
                .WithDescription("Ensure optimal performance through code splitting, memoization, and lazy loading")
                .WithRationale("Performance directly impacts user experience, engagement, and SEO rankings"))
            .WithObjective(o => o
                .WithId("OBJ-REACT-3")
                .WithDescription("Leverage TypeScript for type safety and enhanced developer experience")
                .WithRationale("TypeScript catches errors at compile time and improves code documentation and IDE support"))
            .WithObjective(o => o
                .WithId("OBJ-REACT-4")
                .WithDescription("Ensure application accessibility following WCAG guidelines")
                .WithRationale("Accessible applications reach wider audiences and meet legal requirements"))
            .WithObjective(o => o
                .WithId("OBJ-REACT-5")
                .WithDescription("Design components for testability with clear contracts and minimal dependencies")
                .WithRationale("Testable components enable confidence in changes and reduce regression bugs"))

            // GLOBAL MUST CONSTRAINTS
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-TS-1")
                .WithText("Use TypeScript for all components, hooks, and utilities")
                .WithRationale("TypeScript provides type safety, better tooling, and self-documenting code"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-FC-1")
                .WithText("Use functional components with hooks instead of class components")
                .WithRationale("Functional components are the modern React standard with better composition and code reuse"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-TSX-1")
                .WithText("Use .tsx extension for files containing JSX/TypeScript")
                .WithRationale("TSX extension enables proper syntax highlighting and type checking"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-NAME-1")
                .WithText("Name components with PascalCase matching the filename (Button.tsx exports Button)")
                .WithRationale("Consistent naming improves navigation and discoverability"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-PROPS-1")
                .WithText("Define TypeScript interfaces for all component props")
                .WithRationale("Prop interfaces provide clear contracts and enable type checking"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-HOOKS-1")
                .WithText("Follow React Hooks rules: only call at top level, only in React functions")
                .WithRationale("Hook rules ensure consistent behavior and prevent bugs"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-STATE-1")
                .WithText("Use appropriate state management: local state (useState), context, or external library (Redux, Zustand)")
                .WithRationale("Proper state placement prevents prop drilling and improves maintainability"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-FOLDER-1")
                .WithText("Organize by feature: components/, pages/, hooks/, services/, types/, utils/")
                .WithRationale("Feature-based organization scales better than technical-based grouping"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-API-1")
                .WithText("Abstract API calls in service layers, not directly in components")
                .WithRationale("Service abstraction enables testing, caching, and API evolution"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-ERROR-1")
                .WithText("Implement error boundaries to catch and handle component errors gracefully")
                .WithRationale("Error boundaries prevent entire app crashes and improve user experience"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-A11Y-1")
                .WithText("Use semantic HTML elements and ARIA attributes where appropriate")
                .WithRationale("Semantic HTML improves accessibility and SEO"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-KEY-1")
                .WithText("Always provide stable, unique keys for list items")
                .WithRationale("Keys help React identify changes and optimize rendering"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-ENV-1")
                .WithText("Use environment variables for configuration (API URLs, feature flags)")
                .WithRationale("Environment variables enable deployment-specific configuration"))
            .WithGlobalMustConstraint(m => m
                .WithId("MUST-REACT-SPLIT-1")
                .WithText("Implement code splitting with React.lazy() and Suspense for routes and heavy components")
                .WithRationale("Code splitting reduces initial bundle size and improves load time"))

            // GLOBAL MUST NOT CONSTRAINTS
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-INLINE-1")
                .WithText("Do not create functions inline in JSX if passed as props - use useCallback")
                .WithRationale("Inline functions cause unnecessary re-renders of child components"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-MUTATE-1")
                .WithText("Never mutate state directly - always use setState or state updater functions")
                .WithRationale("Direct mutation bypasses React's change detection and causes bugs"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-IDX-1")
                .WithText("Do not use array indexes as keys unless list is static and never reordered")
                .WithRationale("Index keys cause rendering issues when list items are added, removed, or reordered"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-LOGIC-1")
                .WithText("Do not put complex business logic in JSX - extract to functions or hooks")
                .WithRationale("Logic in JSX reduces readability and testability"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-DEPS-1")
                .WithText("Do not ignore ESLint warnings about missing useEffect/useCallback dependencies")
                .WithRationale("Missing dependencies cause stale closures and bugs"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-ANY-1")
                .WithText("Avoid 'any' type in TypeScript - use specific types or generics")
                .WithRationale("'any' defeats TypeScript's purpose and hides potential bugs"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-LOG-1")
                .WithText("Do not leave console.log statements in production code")
                .WithRationale("Console statements leak implementation details and reduce performance"))
            .WithGlobalMustNotConstraint(mn => mn
                .WithId("MUSTNOT-REACT-LARGE-1")
                .WithText("Do not create components larger than 300 lines - break into smaller components")
                .WithRationale("Large components are hard to understand, test, and maintain"))

            // ASSUMPTIONS
            .WithAssumption(a => a
                .WithId("AS-REACT-1")
                .WithDescription("React 18+ with TypeScript 5+ and modern build tools (Vite or Create React App)")
                .WithRationale("Modern React features like Suspense, concurrent rendering, and automatic batching"))
            .WithAssumption(a => a
                .WithId("AS-REACT-2")
                .WithDescription("Single-Page Application (SPA) architecture with client-side routing")
                .WithRationale("SPA provides smooth navigation and app-like experience"))
            .WithAssumption(a => a
                .WithId("AS-REACT-3")
                .WithDescription("Backend provides RESTful API with JSON responses")
                .WithRationale("REST is the most common API pattern for React applications"))
            .WithAssumption(a => a
                .WithId("AS-REACT-4")
                .WithDescription("Target modern browsers with ES6+ support")
                .WithRationale("Modern browsers enable use of latest JavaScript features"))
            .WithAssumption(a => a
                .WithId("AS-REACT-5")
                .WithDescription("NPM or Yarn for package management")
                .WithRationale("NPM ecosystem provides vast library of React components and utilities"))

            // GLOSSARY
            .WithGlossaryTerm(g => g
                .WithTerm("Component")
                .WithDefinition("Reusable, self-contained piece of UI with its own logic and rendering"))
            .WithGlossaryTerm(g => g
                .WithTerm("Hook")
                .WithDefinition("Function that lets you use React features like state and lifecycle in functional components (useState, useEffect, etc.)"))
            .WithGlossaryTerm(g => g
                .WithTerm("Props")
                .WithDefinition("Properties passed from parent to child components, making components configurable and reusable"))
            .WithGlossaryTerm(g => g
                .WithTerm("State")
                .WithDefinition("Data that changes over time within a component, triggering re-renders when updated"))
            .WithGlossaryTerm(g => g
                .WithTerm("JSX (JavaScript XML)")
                .WithDefinition("Syntax extension allowing HTML-like code in JavaScript, transpiled to React.createElement() calls"))
            .WithGlossaryTerm(g => g
                .WithTerm("Virtual DOM")
                .WithDefinition("In-memory representation of the actual DOM, enabling efficient updates through reconciliation"))
            .WithGlossaryTerm(g => g
                .WithTerm("Context")
                .WithDefinition("React feature for passing data through component tree without prop drilling"))
            .WithGlossaryTerm(g => g
                .WithTerm("Redux/Zustand")
                .WithDefinition("State management libraries for managing complex, global application state outside React's component tree"))
            .WithGlossaryTerm(g => g
                .WithTerm("React Router")
                .WithDefinition("Standard library for client-side routing in React SPAs"))
            .WithGlossaryTerm(g => g
                .WithTerm("Code Splitting")
                .WithDefinition("Technique to split JavaScript bundle into smaller chunks loaded on demand"))
            .WithGlossaryTerm(g => g
                .WithTerm("Memoization")
                .WithDefinition("Performance optimization caching expensive computations (useMemo) or components (React.memo)"))
            .WithGlossaryTerm(g => g
                .WithTerm("Error Boundary")
                .WithDefinition("React component that catches JavaScript errors in child component tree and displays fallback UI"))

            // COMMANDS
            .WithCommand(c => c
                .WithName("create-react-app")
                .WithDescription("Create new React application with TypeScript")
                .WithExample("npx create-react-app my-app --template typescript"))
            .WithCommand(c => c
                .WithName("create-vite-app")
                .WithDescription("Create React app with Vite (faster alternative)")
                .WithExample("npm create vite@latest my-app -- --template react-ts"))
            .WithCommand(c => c
                .WithName("add-component")
                .WithDescription("Create new React component with TypeScript")
                .WithExample("Create Button.tsx in components/ with Props interface"))
            .WithCommand(c => c
                .WithName("add-route")
                .WithDescription("Add new route to React Router configuration")
                .WithExample("Add <Route path='/about' element={<About />} /> to router"))
            .WithCommand(c => c
                .WithName("install-deps")
                .WithDescription("Install project dependencies")
                .WithExample("npm install"))
            .WithCommand(c => c
                .WithName("run-dev")
                .WithDescription("Start development server")
                .WithExample("npm run dev"))
            .WithCommand(c => c
                .WithName("run-tests")
                .WithDescription("Execute test suite")
                .WithExample("npm test"))
            .WithCommand(c => c
                .WithName("build-production")
                .WithDescription("Create optimized production build")
                .WithExample("npm run build"))

            // STEPS
            .WithStep(s => s
                .WithTitle("Initialize React Project")
                .WithDescription("Create the React application using modern tooling (Vite or Create React App) with TypeScript configuration.")
                .WithExpectedOutcome("React project initialized with TypeScript, proper folder structure, and development server running.")
                .WithMustConstraint(m => m
                    .WithId("STEP1-VITE-1")
                    .WithText("Use Vite for new projects (faster) or Create React App (more established)")
                    .WithRationale("Vite offers significantly faster build and HMR; CRA is more opinionated with zero config"))
                .WithMustConstraint(m => m
                    .WithId("STEP1-TS-1")
                    .WithText("Use TypeScript template during project creation")
                    .WithRationale("Setting up TypeScript from start is easier than adding later")))

            .WithStep(s => s
                .WithTitle("Configure TypeScript and ESLint")
                .WithDescription("Set up TypeScript configuration and linting rules for code quality and consistency.")
                .WithExpectedOutcome("TypeScript strict mode enabled, ESLint configured with React and TypeScript rules.")
                .WithMustConstraint(m => m
                    .WithId("STEP2-STRICT-1")
                    .WithText("Enable TypeScript strict mode in tsconfig.json")
                    .WithRationale("Strict mode catches more errors and enforces best practices"))
                .WithMustConstraint(m => m
                    .WithId("STEP2-ESLINT-1")
                    .WithText("Install and configure eslint-plugin-react, eslint-plugin-react-hooks, @typescript-eslint")
                    .WithRationale("ESLint plugins enforce React best practices and hook rules")))

            .WithStep(s => s
                .WithTitle("Set Up Routing with React Router")
                .WithDescription("Configure client-side routing using React Router for navigation between pages.")
                .WithExpectedOutcome("React Router configured with routes for main pages and navigation components.")
                .WithMustConstraint(m => m
                    .WithId("STEP3-ROUTER-1")
                    .WithText("Install React Router v6+ (latest version)")
                    .WithRationale("v6 provides improved API with hooks and better TypeScript support"))
                .WithMustConstraint(m => m
                    .WithId("STEP3-LAZY-1")
                    .WithText("Use React.lazy() and Suspense for route-level code splitting")
                    .WithRationale("Lazy loading routes reduces initial bundle size")))

            .WithStep(s => s
                .WithTitle("Design Component Architecture")
                .WithDescription("Establish component patterns, naming conventions, and composition strategies.")
                .WithExpectedOutcome("Component library with clear separation between presentational and container components.")
                .WithMustConstraint(m => m
                    .WithId("STEP4-TYPES-1")
                    .WithText("Distinguish presentational (UI) components from container (logic) components")
                    .WithRationale("Separation improves reusability and testability"))
                .WithMustConstraint(m => m
                    .WithId("STEP4-PROPS-1")
                    .WithText("Define Props interface for every component with TypeScript")
                    .WithRationale("Explicit props provide clear contracts and type safety")))

            .WithStep(s => s
                .WithTitle("Implement State Management")
                .WithDescription("Set up state management strategy using useState, Context API, or external library like Redux/Zustand.")
                .WithExpectedOutcome("State management solution configured for local, shared, and global state.")
                .WithMustConstraint(m => m
                    .WithId("STEP5-PLACEMENT-1")
                    .WithText("Use useState for component-local state, Context for shared state, Redux/Zustand for complex global state")
                    .WithRationale("Appropriate state placement prevents over-engineering and prop drilling"))
                .WithMustConstraint(m => m
                    .WithId("STEP5-CONTEXT-1")
                    .WithText("Create custom Context providers for auth, theme, and other cross-cutting concerns")
                    .WithRationale("Context providers centralize shared state and logic")))

            .WithStep(s => s
                .WithTitle("Create Custom Hooks")
                .WithDescription("Develop reusable custom hooks for common functionality like API calls, form handling, and side effects.")
                .WithExpectedOutcome("Library of custom hooks abstracting common patterns and logic.")
                .WithMustConstraint(m => m
                    .WithId("STEP6-NAMING-1")
                    .WithText("Name custom hooks with 'use' prefix (useAuth, useFetch, useForm)")
                    .WithRationale("'use' prefix indicates hook and enables ESLint rules"))
                .WithMustConstraint(m => m
                    .WithId("STEP6-COMPOSE-1")
                    .WithText("Compose custom hooks from built-in hooks (useState, useEffect, etc.)")
                    .WithRationale("Hook composition enables code reuse and separation of concerns")))

            .WithStep(s => s
                .WithTitle("Configure API Integration")
                .WithDescription("Set up HTTP client (Axios/Fetch) and create service layer for API communication.")
                .WithExpectedOutcome("API service layer with typed endpoints, error handling, and request/response interceptors.")
                .WithMustConstraint(m => m
                    .WithId("STEP7-CLIENT-1")
                    .WithText("Create configured Axios instance or Fetch wrapper with base URL and defaults")
                    .WithRationale("Centralized API client enables consistent configuration and interceptors"))
                .WithMustConstraint(m => m
                    .WithId("STEP7-TYPES-1")
                    .WithText("Define TypeScript interfaces for all API request and response types")
                    .WithRationale("Typed APIs prevent runtime errors and improve developer experience")))

            .WithStep(s => s
                .WithTitle("Implement Authentication")
                .WithDescription("Build authentication flow with login, token storage, protected routes, and logout.")
                .WithExpectedOutcome("Complete authentication system with JWT storage, auth context, and route protection.")
                .WithMustConstraint(m => m
                    .WithId("STEP8-CONTEXT-1")
                    .WithText("Create AuthContext providing user state and auth methods (login, logout)")
                    .WithRationale("Centralized auth state enables access from any component"))
                .WithMustConstraint(m => m
                    .WithId("STEP8-TOKEN-1")
                    .WithText("Store JWT tokens in httpOnly cookies or secure localStorage with encryption")
                    .WithRationale("Secure storage prevents XSS token theft")))

            .WithStep(s => s
                .WithTitle("Handle Forms and Validation")
                .WithDescription("Implement form handling with validation using React Hook Form or Formik.")
                .WithExpectedOutcome("Forms with controlled inputs, validation rules, error display, and submission handling.")
                .WithMustConstraint(m => m
                    .WithId("STEP9-LIBRARY-1")
                    .WithText("Use React Hook Form (performant) or Formik (feature-rich) for form management")
                    .WithRationale("Form libraries reduce boilerplate and provide validation"))
                .WithMustConstraint(m => m
                    .WithId("STEP9-SCHEMA-1")
                    .WithText("Define validation schemas using Yup or Zod")
                    .WithRationale("Schema validation ensures data integrity and reusability")))

            .WithStep(s => s
                .WithTitle("Configure Styling Solution")
                .WithDescription("Set up styling approach using CSS Modules, Styled Components, or Tailwind CSS.")
                .WithExpectedOutcome("Consistent styling system with theme, reusable styles, and responsive design.")
                .WithMustConstraint(m => m
                    .WithId("STEP10-CHOICE-1")
                    .WithText("Choose: CSS Modules (scoped CSS), Styled Components (CSS-in-JS), or Tailwind (utility-first)")
                    .WithRationale("Each approach has tradeoffs; choose based on team preference and project needs"))
                .WithMustConstraint(m => m
                    .WithId("STEP10-DESIGN-1")
                    .WithText("Define design tokens for colors, spacing, typography in theme configuration")
                    .WithRationale("Design system ensures consistency and enables easy theme changes")))

            .WithStep(s => s
                .WithTitle("Implement Error Handling")
                .WithDescription("Create error boundaries, error pages, and global error handling strategies.")
                .WithExpectedOutcome("Comprehensive error handling with fallback UI, error logging, and user notifications.")
                .WithMustConstraint(m => m
                    .WithId("STEP11-BOUNDARY-1")
                    .WithText("Wrap application sections in ErrorBoundary components")
                    .WithRationale("Error boundaries prevent full app crashes and provide fallback UI"))
                .WithMustConstraint(m => m
                    .WithId("STEP11-LOGGING-1")
                    .WithText("Integrate error tracking service (Sentry, LogRocket) for production errors")
                    .WithRationale("Error tracking enables debugging production issues")))

            .WithStep(s => s
                .WithTitle("Optimize Performance")
                .WithDescription("Implement performance optimizations including memoization, lazy loading, and bundle optimization.")
                .WithExpectedOutcome("Optimized application with reduced bundle size, faster load times, and smooth interactions.")
                .WithMustConstraint(m => m
                    .WithId("STEP12-MEMO-1")
                    .WithText("Wrap expensive components in React.memo() to prevent unnecessary re-renders")
                    .WithRationale("Memoization improves performance for expensive components"))
                .WithMustConstraint(m => m
                    .WithId("STEP12-CALLBACK-1")
                    .WithText("Use useCallback for functions passed as props to memoized children")
                    .WithRationale("useCallback prevents function recreation and child re-renders")))

            .WithStep(s => s
                .WithTitle("Ensure Accessibility")
                .WithDescription("Implement accessibility features following WCAG guidelines for inclusive design.")
                .WithExpectedOutcome("Accessible application passing WCAG 2.1 Level AA standards with keyboard navigation and screen reader support.")
                .WithMustConstraint(m => m
                    .WithId("STEP13-SEMANTIC-1")
                    .WithText("Use semantic HTML elements (header, nav, main, article, button)")
                    .WithRationale("Semantic elements convey meaning to assistive technologies"))
                .WithMustConstraint(m => m
                    .WithId("STEP13-ARIA-1")
                    .WithText("Add ARIA labels and roles where semantic HTML is insufficient")
                    .WithRationale("ARIA attributes improve screen reader experience")))

            .WithStep(s => s
                .WithTitle("Write Tests")
                .WithDescription("Create comprehensive test suite using Jest and React Testing Library.")
                .WithExpectedOutcome("Test coverage >80% with unit tests for components, integration tests for user flows, and E2E tests.")
                .WithMustConstraint(m => m
                    .WithId("STEP14-LIBRARY-1")
                    .WithText("Use React Testing Library for component testing (not Enzyme)")
                    .WithRationale("Testing Library promotes testing user behavior over implementation"))
                .WithMustConstraint(m => m
                    .WithId("STEP14-UNIT-1")
                    .WithText("Write unit tests for components, hooks, and utility functions")
                    .WithRationale("Unit tests catch regressions and document expected behavior")))

            .WithStep(s => s
                .WithTitle("Configure Environment and Build")
                .WithDescription("Set up environment variables, build configurations, and deployment preparation.")
                .WithExpectedOutcome("Multi-environment configuration with optimized production builds ready for deployment.")
                .WithMustConstraint(m => m
                    .WithId("STEP15-ENV-1")
                    .WithText("Create .env files for each environment (.env.development, .env.production)")
                    .WithRationale("Environment files enable configuration per deployment target"))
                .WithMustConstraint(m => m
                    .WithId("STEP15-PREFIX-1")
                    .WithText("Prefix React environment variables with REACT_APP_ or VITE_")
                    .WithRationale("Prefix ensures variables are embedded in build")))

            .WithStep(s => s
                .WithTitle("Implement Monitoring and Analytics")
                .WithDescription("Integrate analytics, performance monitoring, and error tracking for production insights.")
                .WithExpectedOutcome("Application instrumented with analytics, performance metrics, and error reporting.")
                .WithMustConstraint(m => m
                    .WithId("STEP16-ANALYTICS-1")
                    .WithText("Integrate Google Analytics, Mixpanel, or similar for user behavior tracking")
                    .WithRationale("Analytics provide insights into user behavior and feature usage"))
                .WithMustConstraint(m => m
                    .WithId("STEP16-PERF-1")
                    .WithText("Use Web Vitals API or library to track Core Web Vitals (LCP, FID, CLS)")
                    .WithRationale("Performance monitoring identifies bottlenecks and user experience issues")))

            .WithStep(s => s
                .WithTitle("Prepare for Deployment")
                .WithDescription("Configure CI/CD pipeline, optimize assets, and prepare deployment strategy.")
                .WithExpectedOutcome("Automated deployment pipeline with production-ready builds and hosting configuration.")
                .WithMustConstraint(m => m
                    .WithId("STEP17-CICD-1")
                    .WithText("Set up CI/CD pipeline with GitHub Actions, GitLab CI, or similar")
                    .WithRationale("Automation ensures consistent builds and rapid deployments"))
                .WithMustConstraint(m => m
                    .WithId("STEP17-HOSTING-1")
                    .WithText("Choose hosting: Vercel, Netlify (easy), AWS S3+CloudFront (scalable), or Docker containers")
                    .WithRationale("Hosting choice depends on scale, cost, and integration needs")))

            .Build();

        prompt.Blueprints = [.. prompt.Blueprints, blueprint];
        return await context.Success();
    }
}
