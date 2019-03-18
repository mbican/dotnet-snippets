using Xunit.Abstractions;

namespace Mbican.DotnetSnippets
{
    public static class Extensions
    {
        /// <summary>
        /// Returns test case context
        /// </summary>
        public static ITest GetTest(this ITestOutputHelper testOutputHelper)
        {
            // source: https://github.com/xunit/xunit/issues/416
            var type = testOutputHelper.GetType();
            var testMember = type.GetField("test", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            return (ITest)testMember.GetValue(testOutputHelper);
        }

        /// <summary>
        /// Resets time portion of <paramref name="dateTimeOffset"/> to 00:00 (midnight) and keeps offset
        /// </summary>
        public static DateTimeOffset ToDateOffset(this DateTimeOffset dateTimeOffset)
            => new DateTimeOffset(dateTimeOffset.DateTime.Date, dateTimeOffset.Offset);

        /// <summary>
        /// Resets time portion of <paramref name="dateTimeOffset"/> to 00:00 (midnight) and keeps offset
        /// </summary>
        public static DateTimeOffset? ToDateOffset(this DateTimeOffset? dateTimeOffset)
            => dateTimeOffset.HasValue
            ? dateTimeOffset.Value.ToDateOffset()
            : (DateTimeOffset?)null;
    }
}