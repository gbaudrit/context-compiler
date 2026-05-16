# Usage Examples

## Basic Usage

### 1. Register the Module

In your application startup:

```csharp
services.AddReactFlowPipelineReportModule();
```

### 2. Run Your Pipeline

Execute any ContextCompiler pipeline. The module will automatically collect events and generate the report at the end.

```csharp
var result = await pipelineRunner.RunAsync(context, cancellationToken);
```

### 3. View the Report

Open the generated `pipeline-report-reactflow.html` in a browser.

## Advanced Scenarios

### Filtering by Pipeline

When you have multiple pipelines running (global + sub-pipelines), use the **Pipeline filter** to focus on one:

1. Open the HTML report
2. In the sidebar, select a pipeline from the "Pipeline" dropdown
3. Only nodes from that pipeline are displayed

### Tracing an Item

To follow the journey of a specific file through the pipeline:

1. Select the item from the "Item" dropdown
2. The graph will show only the steps that processed that item
3. Click on any step to see detailed timing and status

### Analyzing Performance

To identify bottlenecks:

1. Look at the duration displayed on completed steps (in milliseconds)
2. Click on steps to see detailed timing in the sidebar
3. Use the minimap to get an overview of the entire pipeline

### Debugging Failures

When a step fails:

1. Failed steps are displayed in red with an error icon (✗)
2. Click on the failed step to see the error message in the sidebar
3. Use filters to see what happened before and after the failure

### Working with Large Pipelines

For pipelines with many steps:

1. **Collapse sub-pipelines**: Click the ▼ button on pipeline/stage nodes
2. **Use filters**: Filter by phase or module to reduce noise
3. **Zoom**: Use mouse wheel or the controls to zoom in/out
4. **Fit view**: Click the "fit view" button to see the entire graph

## Example Scenarios

### Scenario 1: Debugging a Failed Pipeline

```
Problem: A pipeline failed but I don't know which step caused it.

Solution:
1. Open pipeline-report-reactflow.html
2. Look for red nodes (failed steps)
3. Click on the failed step
4. Read the error message in the sidebar
5. Use the "Item" filter to see what item caused the failure
6. Check the steps before the failure to understand the context
```

### Scenario 2: Performance Optimization

```
Problem: The pipeline is slow and I need to find bottlenecks.

Solution:
1. Open the report
2. Look at the duration on each step
3. Sort mentally by duration (longer bars = slower steps)
4. Click on slow steps to see details
5. Use the "Module" filter to see if a specific module is slow
6. Analyze patterns (e.g., certain file types take longer)
```

### Scenario 3: Understanding Pipeline Flow

```
Problem: I need to understand how data flows through the pipeline.

Solution:
1. Open the report
2. Use the minimap to get an overview
3. Follow the arrows from left to right (stages)
4. Expand/collapse stages to see more or less detail
5. Use the "Phase" filter to focus on one phase at a time
6. Click on nodes to see relationships (parent pipeline, module used)
```

### Scenario 4: Comparing Two Pipeline Runs

```
Problem: I made changes and want to compare before/after.

Solution:
1. Run the pipeline before changes → save report as before.html
2. Make your changes
3. Run the pipeline again → save report as after.html
4. Open both files in separate browser tabs
5. Compare:
   - Number of steps (did you add/remove steps?)
   - Duration (is it faster/slower?)
   - Failures (did you fix/introduce errors?)
```

## UI Controls Reference

### Graph Area

- **Mouse wheel**: Zoom in/out
- **Click + drag**: Pan the graph
- **Click on node**: Select and show details
- **Double-click on node**: Center on node

### Minimap

- Shows overview of the entire graph
- Purple = pipelines
- Blue = stages
- Light blue = steps
- Red rectangle = current viewport

### Controls (Bottom-left)

- **+**: Zoom in
- **−**: Zoom out
- **⊡**: Fit view (show entire graph)
- **🔒**: Lock zoom

### Sidebar (Right)

#### Filters Section

- **Pipeline**: Filter by specific pipeline
- **Phase**: Filter by phase (Setup, InputDiscovery, etc.)
- **Module**: Filter by module ID
- **Item**: Filter by item ID (file, etc.)
- **Clear All**: Remove all filters

#### View Options

- **Show Pipeline IDs**: Display full pipeline IDs in labels
- **Show Hierarchy Links**: Display parent/child relationships

#### Node Details

Shows detailed information about the selected node:
- Pipeline: ID, name, parent, number of stages
- Stage: ID, name, pipeline, number of steps
- Step: Name, module, item, status, duration, timestamps, error

## Tips and Tricks

### 1. Keyboard Shortcuts

- **Ctrl/Cmd + F**: Browser search (find text in sidebar)
- **Ctrl/Cmd + Mouse wheel**: Faster zoom

### 2. Browser DevTools

Open browser console (F12) to see debug information:
- `window.PIPELINE_DATA`: View raw data
- React DevTools: Inspect component state

### 3. Sharing Reports

The HTML file is self-contained:
- No server needed
- Can be shared via email, file share, etc.
- Open directly in any modern browser
- No internet connection required

### 4. Troubleshooting

**Graph not displaying?**
- Check browser console for errors
- Ensure Node.js was available when the .NET module ran
- Try opening in a different browser

**Performance issues?**
- Use filters to reduce visible nodes
- Collapse sub-pipelines
- Try a browser with better performance (Chrome, Edge)

**Layout looks weird?**
- Click "Fit view" to reset
- Refresh the page
- Check if the pipeline has circular dependencies

## Integration Examples

### Example 1: CI/CD Pipeline

```csharp
// In your CI/CD pipeline
services.AddReactFlowPipelineReportModule();

var result = await runner.RunAsync(context);

// The report is automatically saved to the output directory
// Archive it as a build artifact for later analysis
```

### Example 2: Batch Processing

```csharp
// Process multiple files and generate a report
services.AddReactFlowPipelineReportModule();

foreach (var file in files)
{
	context.AddInput(file);
}

var result = await runner.RunAsync(context);

// Open pipeline-report-reactflow.html to see which files succeeded/failed
```

### Example 3: Development Debugging

```csharp
// During development, generate a report for every run
services.AddReactFlowPipelineReportModule();

var result = await runner.RunAsync(context);

// Open the report in your browser to visualize execution
// Much easier than reading logs!
```

## Common Patterns

### Pattern 1: Focus on Failed Items

```
1. Open report
2. Look for red nodes (failed steps)
3. Click on a failed step
4. Note the Item ID
5. Use the "Item" filter with that ID
6. See the complete journey of that item
```

### Pattern 2: Performance Profiling

```
1. Open report
2. Look for steps with high duration
3. Group by module (use "Module" filter)
4. Identify slow modules
5. Click on slow steps to see details
6. Optimize those modules
```

### Pattern 3: Pipeline Overview

```
1. Open report
2. Use minimap to see overall structure
3. Collapse all stages
4. Expand only the stage you're interested in
5. Use filters to drill down further
```

## FAQ

**Q: Can I edit the graph?**
A: No, the graph is read-only. It's a visualization of what happened, not an editor.

**Q: Can I export the graph?**
A: Not currently, but you can take a screenshot. Future versions may support SVG/PNG export.

**Q: How do I see multiple pipelines at once?**
A: By default, all pipelines are shown. Use the minimap for an overview, or collapse pipelines you're not interested in.

**Q: Can I filter by date/time?**
A: Not directly, but you can see timestamps in the node details and use browser search to find specific times.

**Q: What browsers are supported?**
A: Any modern browser (Chrome, Edge, Firefox, Safari). Chrome/Edge recommended for best performance.

**Q: Can I customize the colors?**
A: Not without modifying the source code. The colors are hardcoded by node type and status.

**Q: How big of a pipeline can it handle?**
A: Tested with up to 5000 nodes. For larger pipelines, use filters to reduce the number of visible nodes.
