using NBomber.Http.CSharp;
using TheMovie.Integration.Tests.Infrastructure;
using System;
using NBomber.CSharp;
using NBomber.Contracts;

namespace TheMovie.Integration.Tests.Base
{
    public class BaseTest
    {
        protected Scenario CreateGetScenario(string nameScenatio, string uri)
        {
            var step = HttpStep.Create("Request step", context => Http.CreateRequest("GET", Constants.MovieService.Url + uri));

            return ScenarioBuilder
                .CreateScenario(nameScenatio, new[] { step })
                .WithConcurrentCopies(10)
                .WithDuration(TimeSpan.FromSeconds(10));
        }
    }
}
