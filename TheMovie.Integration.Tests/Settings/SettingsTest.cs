using NBomber.CSharp;
using NUnit.Framework;
using TheMovie.Integration.Tests.Base;

namespace TheMovie.Integration.Tests.Settings
{
    [TestFixture]
    public class SettingsTest : BaseTest
    {
        [Test]
        public void GetLanguagesEndpoint_ShouldSuccess()
        {
            var scenario = CreateGetScenario("Test Get Languages Scenario", "/settings/languages");

            NBomberRunner.RegisterScenarios(new[] { scenario }).RunTest();
        }
    }
}
