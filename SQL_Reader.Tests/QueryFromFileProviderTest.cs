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
        [InlineData("\r\n\r\n\r\n 123 --blablabla", "123")]
        [InlineData("123\r\n --komentarz","123")]
        [InlineData("", "List of Queries is empty!")]

        public void GetQueries_ResultShouldBeAsExpected(string input, string expected)
        {
            List<string> lines = new List<string>();
            lines.Add(input);
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Equal(expected, result.ElementAt(0));
        }
        [Fact]
        public void GetQueries_isNull()
        {
            List<string> lines = new List<string>();
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Equal("List of Queries is empty!", result.ElementAt(0));
        }
    }

}
