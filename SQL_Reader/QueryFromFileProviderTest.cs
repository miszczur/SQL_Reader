using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace SQL_Reader.Tests
{
    public class QueryFromFileProviderTest

    {
        [Theory]
        [InlineData("123--komentarz", "123")]
        [InlineData("123 --komentarz", "123")]
        [InlineData(" 123 --komentarz", "123")]
        [InlineData("--blablabla", "")]
        [InlineData("123\r\n --komentarz","123")]
        public void Result_ShouldBe_AsExpected(string input, string expected)
        {
            List<string> lines = new List<string>();
            lines.Add(input);
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Equal(expected, result.ElementAt(0));
        }
    }

}
