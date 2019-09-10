using System;
using System.IO;
using Xunit;
using GDP;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace gdptask.test
{
    public class Class1
    {
        
         [Fact]
         public void Test1(){

           string path1=@"C:\Users\CGI\Desktop\C#_fund\gdp\data\expected.json";
           string path2=@"C:\Users\CGI\Desktop\C#_fund\gdp\output\output.json";
            JToken xpctJSON=JsonConvert.DeserializeObject<JToken>(File.ReadAllText(path1));
             JToken actJSON=JsonConvert.DeserializeObject<JToken>(File.ReadAllText(path2));
            bool res = JToken.DeepEquals(xpctJSON, actJSON);
            Assert.True(res);
           

        
        // var act = JsonConvert.DeserializeObject(@"C:\Users\CGI\Desktop\C#_fund\gdp1\output\output.json");
        // var exp = JsonConvert.DeserializeObject(@"C:\Users\CGI\Desktop\C#_fund\gdp1\GDP.Tests\expected-output.json");
        // act.Should().BeEquivalentTo(exp);
         }
    }
}
