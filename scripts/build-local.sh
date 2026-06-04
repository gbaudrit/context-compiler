#!/usr/bin/env bash
set -euo pipefail

VERSION="${1:-0.1.0}"
# AssemblyVersion / FileVersion must be strictly numeric.
NUMERIC_VERSION="${VERSION%%[-+]*}"
PROJECT="src/Core/ContextCompiler.Cli/ContextCompiler.Cli.csproj"

mkdir -p artifacts

dotnet publish "$PROJECT" -c Release -r linux-x64 --self-contained true \
  /p:PublishSingleFile=true /p:PublishTrimmed=false \
  /p:AssemblyVersion="$NUMERIC_VERSION" /p:FileVersion="$NUMERIC_VERSION" /p:InformationalVersion="$VERSION" \
  -o publish/linux-x64

tar -czf artifacts/ctxc-linux-x64.tar.gz -C publish/linux-x64 .
