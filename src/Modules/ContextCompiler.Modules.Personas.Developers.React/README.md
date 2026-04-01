# ContextCompiler.Modules.Personas.Developers.React

## Overview

This module provides a **React Developer** persona for the ContextCompiler system. It defines a set of best practices, coding standards, and constraints specifically tailored for modern React development with TypeScript.

## Features

- **Persona ID**: `developers.react`
- **Language**: English
- **Focus**: Modern React development with TypeScript, hooks, and best practices

## Commands

The module provides the following commands for the React Developer persona:

1. **create-component**: Create a new React component with TypeScript
2. **create-hook**: Create a custom React hook
3. **write**: Write React code that responds to functional requirements

## Best Practices Enforced

### MUST Do

- ✅ Use TypeScript for type safety
- ✅ Use functional components with hooks
- ✅ Follow React Hooks rules
- ✅ Implement proper state management (useState, Context, Redux/Zustand)
- ✅ Organize code by feature (components/, pages/, hooks/, services/)
- ✅ Abstract API calls in service layers
- ✅ Implement error boundaries
- ✅ Use semantic HTML and ARIA attributes
- ✅ Provide stable, unique keys for list items
- ✅ Implement code splitting with React.lazy() and Suspense
- ✅ Use useCallback and useMemo for performance optimization
- ✅ Name custom hooks with 'use' prefix
- ✅ Write tests with React Testing Library
- ✅ Maintain >80% test coverage
- ✅ Follow WCAG accessibility guidelines
- ✅ Use environment variables for configuration
- ✅ Monitor performance with Web Vitals
- ✅ Set up CI/CD pipeline

### MUST NOT Do

- ❌ Do not create inline functions in JSX props without useCallback
- ❌ Never mutate state directly
- ❌ Do not use array indexes as keys for dynamic lists
- ❌ Do not put complex business logic in JSX
- ❌ Do not ignore ESLint dependency warnings
- ❌ Avoid 'any' type in TypeScript
- ❌ Do not leave console.log in production
- ❌ Do not create components larger than 300 lines
- ❌ Do not store sensitive tokens without encryption
- ❌ Never commit .env files or secrets
- ❌ Avoid class components unless necessary
- ❌ Do not perform side effects directly in render
- ❌ Avoid prop drilling without Context/state management
- ❌ Do not fetch data in useEffect without cleanup

## Usage

This module is automatically loaded when the ContextCompiler system starts. It registers the React Developer persona and makes it available for use in prompts and workflows.

### Example Configuration

```json
{
  "personas": ["developers.react"]
}
```

## Integration with Blueprints

This module works seamlessly with the **React Frontend Blueprint** (`ContextCompiler.Blueprints.React.Frontend`) to provide comprehensive guidance for building modern React applications.

## Package Information

- **Package ID**: `ContextCompiler.Modules.Personas.Developers.React`
- **Authors**: ContextCompiler
- **Tags**: context, compiler, module, personas, developer, react, frontend, typescript, javascript

## Dependencies

- `ContextCompiler.Modules.Abstractions`

## License

See the root LICENSE file for license information.
