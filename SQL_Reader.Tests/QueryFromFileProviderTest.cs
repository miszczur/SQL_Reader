using Xunit;
using System.Collections.Generic;
using System.Linq;
using SQL_Reader;
using System;
using System.Threading.Tasks;
using System.Text;


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
        

        public void GetQueries_ResultShouldBeAsExpected(string input, string expected)
        {
            List<string> lines = new List<string>();
            lines.Add(input);
            var provider = new QueryFromFileProvider(lines);
            var result = provider.GetQueries();
            Assert.Equal(expected, result.ElementAt(0));
        }

        
        
    }

}
