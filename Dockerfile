FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .
RUN dotnet publish src/Core/ContextCompiler.Cli/ContextCompiler.Cli.csproj \
	-c Release \
	-r linux-x64 \
	--self-contained true \
	/p:PublishSingleFile=true \
	/p:PublishTrimmed=false \
	-o /out

FROM mcr.microsoft.com/dotnet/runtime-deps:10.0-noble-chiseled

LABEL org.opencontainers.image.title="ContextCompiler" \
      org.opencontainers.image.description="CLI-first tool for compiling context inputs into structured outputs, prompts, reports and artifacts." \
      org.opencontainers.image.url="https://contextcompiler.io" \
      org.opencontainers.image.documentation="https://contextcompiler.io/docs" \
      org.opencontainers.image.source="https://github.com/gbaudrit/context-compiler" \
      org.opencontainers.image.vendor="Guillaume Baudrit" \
      org.opencontainers.image.licenses="MIT"

WORKDIR /workspace
COPY --from=build /out/ctxc /usr/local/bin/ctxc
ENTRYPOINT ["ctxc"]
