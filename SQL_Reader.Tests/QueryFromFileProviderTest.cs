using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SQL_Reader.Tests
{
    public class QueryFromFileProviderTest

    {
        [Theory]
        [InlineData("123;--komentarz", "123;")]
        [InlineData("123; --komentarz", "123;")]
        [InlineData(" 123; --komentarz;", "123;")]
        [InlineData("\r\n\r\n\r\n 123; --blablabla", "123;")]
        [InlineData("123;\r\n --komentarz", "123;")]
       
      


        public void GetQueries_ResultShouldBeAsExpected(string input, string expected)
        {
            List<string> lines = new List<string>();
            lines.Add(input);
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Equal(expected, result.ElementAt(0));
        }
     
        [Theory]
        [InlineData(@"INSERT INTO TMP_MENU( PROGRAMIDENT, PRGPATH,  KABEL, KABELIDENT, OPIS, SPECIALIDX, CHIP, SHOWTOUSER, FUNCTIONALITY, CABLEGROUP)\r\n",
            @"VALUES(3027, 'CARS\ACURA\93C46', 'C12', 139, 0, 0, 68, 1, 36, 1);",
            @"INSERT INTO TMP_MENU( PROGRAMIDENT, PRGPATH,  KABEL, KABELIDENT, OPIS, SPECIALIDX, CHIP, SHOWTOUSER, FUNCTIONALITY, CABLEGROUP)\r\nVALUES(3027, 'CARS\ACURA\93C46', 'C12', 139, 0, 0, 68, 1, 36, 1);")]
        public void GetQueries_ResultShouldBeAsExpectedWithQueriesInTwoLines(string input1, string input2, string expected)
        {
            List<string> lines = new List<string>();
            lines.Add(input1);
            lines.Add(input2);
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Equal(expected, result.ElementAt(0));
        }

        [Fact]
        public void GetQueries_WithNullParameterShouldThrowMyException()
        {
            List<string> newObject = null;
            Assert.Throws<QueryFromFileProviderNullLineException>(() => new QueryFromFileProvider(newObject));
        }

        [Fact]
        public void GetQueries_ResultShouldBeEmpty()
        {
            string input = "--textToRemove";
            List<string> lines = new List<string>();
            lines.Add(input);
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Empty(result);
        }

        [Fact]
        public void GetQueries_ListHaveOnlyWhitespaceResultShouldBeEmpty()
        {
            List<string> lines = new List<string> { "" };
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Empty(result);
        }

        [Fact]
        public void GetQueries_ListIsEmptyResultShouldBeEmpty()
        {
            List<string> lines = new List<string>();
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Empty(result);
        }
    }
}
