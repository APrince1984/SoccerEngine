using NUnit.Framework;
using SoccerDataGenerator.Extensions;

namespace SoccerDataGenerator.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void RemoveSpaces_RemovesAllSpacesInAString()
        {
            var stringWithSpaces = "This is a string with spaces";
            var expectedString = "Thisisastringwithspaces";
            var newString = stringWithSpaces.RemoveSpaces();
            Assert.AreEqual(expectedString, newString);
        }
    }
}
