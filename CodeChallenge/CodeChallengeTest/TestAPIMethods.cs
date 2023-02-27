using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;


namespace CodeChallengeTest
{
    [TestClass]
    public class TestAPIMethods
    {
        
        [TestMethod]
        [DataRow("1234!@#$", "1234!@#$")] // Test input with no words
        [DataRow("hello", "h2o")] // Test input with one word
        [DataRow("it was many and many a year ago", "i0t w1s m2y a1d m2y a y2r a1o")] // Test input with multiple words
        [DataRow("Copyright,Microsoft:Corporation", "C7t,M6t:C6n")] // Test input with multiple words       

        public void TestParseSentence(string input, string expected)
        {
            //Arrange
            var result = new Service();
            
            //Act 
            string actual =  result.GetResult(input);
            
            //Assert
            Assert.AreEqual(expected, actual);            
            
        }        

    }
}

