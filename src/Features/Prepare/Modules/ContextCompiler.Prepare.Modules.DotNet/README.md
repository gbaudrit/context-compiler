# ContextCompiler.Prepare.Modules.DotNet

Static .NET project analysis module for the Context Compiler Prepare pipeline.

The module emits `.ctxc/prepare/dotnet.analysis.json` when a project contains .NET markers such as `.csproj`, `.sln`, `global.json`, `Directory.Build.props`, or `Directory.Packages.props`.
