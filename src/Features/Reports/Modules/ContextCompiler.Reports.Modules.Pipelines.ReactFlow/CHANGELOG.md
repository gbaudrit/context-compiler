# Changelog

All notable changes to this module will be documented in this file.

## [1.0.0] - 2024-01-XX

### Added

- Initial release of React Flow pipeline visualization module
- Interactive graph visualization with zoom, pan and minimap
- Automatic layout using ELK.js with hierarchical horizontal arrangement
- Support for large graphs (thousands of nodes)
- Pipeline hierarchy visualization (parent/child relationships)
- Collapse/expand functionality for sub-pipelines
- Color coding by type (pipeline, stage, step) and status
- Detail panel showing node information on selection
- Dynamic filters (pipeline, phase, module, item)
- Lazy loading support for sub-graphs
- Performance optimizations (memoization, virtualization)
- Static HTML export with embedded data
- Integration with ContextCompiler pipeline events

### Technical Stack

- React 18+ with TypeScript
- Vite for build tooling
- React Flow for graph rendering
- ELK.js for automatic layout
- Zustand for state management

### Dependencies

- Requires Node.js 18+ for building the React application
- Built on top of ContextCompiler.Modules.Abstractions
