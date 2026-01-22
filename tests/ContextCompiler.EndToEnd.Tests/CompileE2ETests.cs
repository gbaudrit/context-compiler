using FluentAssertions;

namespace ContextCompiler.EndToEnd.Tests;

[TestClass]
public sealed class CompileE2ETests
{
    [TestMethod]
    public void PlaceholderShouldPass()
    {
        true.Should().BeTrue();
    }
}
