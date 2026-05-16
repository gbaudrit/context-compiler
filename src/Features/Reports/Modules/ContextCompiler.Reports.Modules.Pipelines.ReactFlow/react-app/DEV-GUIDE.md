# Development Guide

## Running in Development Mode

### Prerequisites

- Node.js 18+ installed
- npm or yarn

### Setup

1. Install dependencies:
```bash
npm install
```

2. Start the development server:
```bash
npm run dev
```

3. Open http://localhost:5173 in your browser

### Testing with Sample Data

For development, you can inject sample data by opening the browser console and running:

```javascript
window.PIPELINE_DATA = {
  "pipelines": [...],
  "stages": [...],
  "steps": [...],
  "edges": [...]
};
```

Then refresh the page.

Alternatively, modify `App.tsx` to load data from a local JSON file during development:

```typescript
// In App.tsx, replace window.PIPELINE_DATA with:
const response = await fetch('/sample-data.json');
const data = await response.json();
```

### Building for Production

```bash
npm run build
```

The output will be in the `dist/` directory.

## Integration with .NET Module

The .NET module (`ReactFlowPipelineReportModule`) will:

1. Collect pipeline events during execution
2. Convert events to JSON using `PipelineDataConverter`
3. Run `npm install` and `npm run build` in the react-app directory
4. Read the built `dist/index.html`
5. Inject the pipeline JSON into the HTML as `window.PIPELINE_DATA`
6. Output the final HTML as an artifact

## File Structure

```
react-app/
├── src/
│   ├── components/
│   │   ├── PipelineNode.tsx      # Pipeline node component
│   │   ├── StageNode.tsx         # Stage node component
│   │   ├── StepNode.tsx          # Step node component
│   │   ├── PipelineGraph.tsx     # Main React Flow graph
│   │   ├── Header.tsx            # Top header with stats
│   │   └── Sidebar.tsx           # Filters and node details
│   ├── services/
│   │   └── layoutService.ts      # ELK layout calculations
│   ├── stores/
│   │   └── graphStore.ts         # Zustand state management
│   ├── hooks/
│   │   └── usePerformance.ts     # Performance optimization hooks
│   ├── types.ts                  # TypeScript type definitions
│   ├── App.tsx                   # Main application component
│   ├── main.tsx                  # React entry point
│   └── index.css                 # Global styles
├── public/
│   └── sample-data.json          # Sample data for development
├── index.html                    # HTML template
├── package.json                  # npm dependencies
├── tsconfig.json                 # TypeScript configuration
├── vite.config.ts                # Vite build configuration
└── README.md                     # This file
```

## Performance Considerations

The application is optimized for large graphs:

- **React.memo**: All node components are memoized
- **useMemo/useCallback**: Expensive computations are cached
- **Zustand**: Lightweight state management
- **ELK.js**: Efficient layout algorithm
- **React Flow**: Built-in virtualization

For graphs with 1000+ nodes:
- Use filters to reduce visible nodes
- Collapse sub-pipelines when not needed
- Consider lazy loading for very large datasets

## Troubleshooting

### Blank screen

Check the browser console for errors. Ensure `window.PIPELINE_DATA` is defined.

### Layout not working

ELK.js calculation may fail for invalid graph structures. Check that:
- All edge source/target nodes exist
- No circular parent-child relationships
- Node IDs are unique

### Performance issues

For very large graphs (5000+ nodes):
- Apply filters to reduce visible nodes
- Collapse pipelines/stages
- Consider implementing incremental rendering
