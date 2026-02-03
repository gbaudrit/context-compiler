using ContextCompiler.Core.Engine;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextCompiler.Core.Tests.Engine;

[TestClass]
public sealed class CompilerEngineTests
{
    [TestMethod]
    public async Task CompileAsync_ShouldReturnZero()
    {
        // Arrange
        var engine = new CompilerEngine(new NullLogger<CompilerEngine>());

        // Act
        var rc = await engine.CompileAsync(new CompileRequest("in", "out"), CancellationToken.None);

        // Assert
        rc.Should().Be(0);
    }
}
