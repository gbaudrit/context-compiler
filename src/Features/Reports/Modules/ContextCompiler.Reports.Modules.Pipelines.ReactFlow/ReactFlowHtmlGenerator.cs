using Microsoft.Extensions.Logging;

namespace ContextCompiler.Reports.Modules.Pipelines.ReactFlow;

/// <summary>
/// Generates static HTML with embedded React Flow visualization.
/// Uses pre-built React app from the dist folder.
/// </summary>
internal static class ReactFlowHtmlGenerator
{
    public static string GenerateHtml(
        string pipelineDataJson,
        ILogger logger,
        string reactAppPath)
    {
        // The reactAppPath is already resolved by ReactFlowPipelineReportModule
        // It points directly to the react-app folder, so we just need to find dist/ inside it

        logger.LogInformation("Checking for dist/ in: {Path}", reactAppPath);

        string distPath = Path.Combine(reactAppPath, "dist");

        if (!Directory.Exists(distPath))
        {
            logger.LogError("Pre-built React app dist/ not found at: {Path}", distPath);
            return GenerateFallbackHtml(pipelineDataJson,
                $"Pre-built React app dist/ not found at: {distPath}",
                "The React app must be built before use. Run: cd react-app && npm install && npm run build");
        }

        // Read the built index.html
        string indexHtmlPath = Path.Combine(distPath, "index.html");
        if (!File.Exists(indexHtmlPath))
        {
            logger.LogError("Built index.html not found at {Path}", indexHtmlPath);
            return GenerateFallbackHtml(pipelineDataJson,
                $"index.html not found at {indexHtmlPath}",
                "The dist folder exists but index.html is missing. Run: cd react-app && npm run build");
        }

        logger.LogInformation("Using pre-built React app from {Path}", distPath);

        string htmlContent = File.ReadAllText(indexHtmlPath);

        // Inline all assets (JS, CSS) to avoid CORS issues with file:// protocol
        string assetsPath = Path.Combine(distPath, "assets");

        if (Directory.Exists(assetsPath))
        {
            logger.LogInformation("Inlining assets from {Path}", assetsPath);

            // Read the original HTML to get the exact script/link tags
            string[] lines = htmlContent.Split('\n');
            List<string> newLines = [];
            List<string> inlinedScripts = []; // Collect scripts to move to end of body

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                bool lineProcessed = false;

                // Check if this line contains a link to a CSS file
                if (trimmedLine.Contains("<link") && trimmedLine.Contains("href=") && trimmedLine.Contains("/assets/"))
                {
                    string[] cssFiles = Directory.GetFiles(assetsPath, "*.css");
                    foreach (string cssFile in cssFiles)
                    {
                        string cssFileName = Path.GetFileName(cssFile);
                        if (trimmedLine.Contains(cssFileName))
                        {
                            string cssContent = File.ReadAllText(cssFile);
                            newLines.Add($"    <style>{cssContent}</style>");
                            logger.LogDebug("Inlined CSS: {FileName}", cssFileName);
                            lineProcessed = true;
                            break;
                        }
                    }
                }
                // Check if this line contains a script tag with src to a JS file
                else if (trimmedLine.Contains("<script") && trimmedLine.Contains("src=") && trimmedLine.Contains("/assets/"))
                {
                    string[] jsFiles = Directory.GetFiles(assetsPath, "*.js");
                    foreach (string jsFile in jsFiles)
                    {
                        string jsFileName = Path.GetFileName(jsFile);
                        if (trimmedLine.Contains(jsFileName))
                        {
                            string jsContent = File.ReadAllText(jsFile);
                            // Collect script to insert at end of body (so DOM is ready)
                            inlinedScripts.Add($"    <script>{jsContent}</script>");
                            logger.LogDebug("Inlined JS: {FileName}", jsFileName);
                            lineProcessed = true;
                            break;
                        }
                    }
                }

                if (!lineProcessed)
                {
                    newLines.Add(line);
                }
            }

            htmlContent = string.Join("\n", newLines);

            // Insert inlined scripts just before </body> so DOM is fully loaded
            if (inlinedScripts.Count > 0)
            {
                string scriptsBlock = string.Join("\n", inlinedScripts);
                htmlContent = htmlContent.Replace("</body>", $"{scriptsBlock}\n  </body>");
            }

            logger.LogInformation("Assets inlined successfully");
        }
        else
        {
            logger.LogWarning("Assets folder not found at {Path}", assetsPath);
        }

        // Inject the pipeline data into the HTML
        string dataScript = $@"
<script>
window.PIPELINE_DATA = {pipelineDataJson};
</script>";

        // Insert before closing </head> tag
        htmlContent = htmlContent.Replace("</head>", $"{dataScript}\n</head>");

        return htmlContent;
    }

    private static string GenerateFallbackHtml(string pipelineDataJson, string errorMessage, string solution)
    {
        return $@"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Pipeline Report - Build Not Available</title>
    <style>
        body {{
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, sans-serif;
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
            background: #f5f5f5;
        }}
        .error-box {{
            background: #fff3cd;
            border: 1px solid #ffc107;
            border-radius: 8px;
            padding: 20px;
            margin-bottom: 20px;
        }}
        .data-box {{
            background: white;
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 20px;
        }}
        pre {{
            background: #f8f9fa;
            padding: 15px;
            border-radius: 4px;
            overflow-x: auto;
            max-height: 600px;
        }}
        h1 {{
            color: #333;
        }}
        h2 {{
            color: #666;
            font-size: 1.2em;
        }}
        .code {{
            background: #f8f9fa;
            padding: 2px 6px;
            border-radius: 3px;
            font-family: monospace;
        }}
    </style>
</head>
<body>
    <h1>⚠️ Pipeline Report - React App Not Built</h1>

    <div class=""error-box"">
        <h2>React App Build Required</h2>
        <p><strong>Error:</strong> {errorMessage}</p>
        <p><strong>Solution:</strong> {solution}</p>
        <p><em>Note: The React app is pre-built and included in the NuGet package. In development, you must build it manually.</em></p>
    </div>

    <div class=""data-box"">
        <h2>Pipeline Data (JSON)</h2>
        <p>Below is the raw pipeline data that would have been visualized:</p>
        <pre>{pipelineDataJson}</pre>
    </div>
</body>
</html>";
    }
}
