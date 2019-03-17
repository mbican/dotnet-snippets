using System;
using Xunit.Abstractions;

namespace Mbican.DotnetSnippets
{
    public abstract class XUnitBaseTests
    {
        protected readonly ITestOutputHelper TestOutput;
        private readonly Lazy<ITest> TestLazy;
        protected ITest Test => TestLazy.Value;
        private readonly Lazy<string> TestIdLazy;
        protected string TestId => TestIdLazy.Value;

        public XUnitBaseTests(ITestOutputHelper testOutputHelper)
        {
            TestOutput = testOutputHelper;
            TestLazy = new Lazy<ITest>(() => TestOutput.GetTest());
            TestIdLazy = new Lazy<string>(() => Test.TestCase.TestMethod.TestClass.Class.Name
                + "/" + Test.TestCase.TestMethod.Method.Name
                // for [Theory] tests there are multiple tests per method they differ in UniqueId
                + "/" + Test.TestCase.UniqueID);
        }
    }
}