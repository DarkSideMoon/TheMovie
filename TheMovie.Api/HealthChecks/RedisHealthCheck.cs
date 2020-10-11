using App.Metrics;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using TheMovie.Api.Configuration;
using TheMovie.Service.Metrics;

namespace TheMovie.Api.HealthChecks
{
    public class RedisHealthCheck : IHealthCheck
    {
        private static readonly ConcurrentDictionary<string, ConnectionMultiplexer> _connections = new ConcurrentDictionary<string, ConnectionMultiplexer>();
        private readonly RedisConfiguration _redisConfiguration;
        private readonly IMetrics _metrics;

        public RedisHealthCheck(IOptions<RedisConfiguration> redisConfiguration, IMetrics metrics)
        {
            _redisConfiguration = redisConfiguration.Value;
            _metrics = metrics;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!_connections.TryGetValue(_redisConfiguration.ConnectionString, out ConnectionMultiplexer connection))
                {
                    connection = await ConnectionMultiplexer.ConnectAsync(_redisConfiguration.ConnectionString);

                    if (!_connections.TryAdd(_redisConfiguration.ConnectionString, connection))
                    {
                        // Dispose new connection which we just created, because we don't need it.
                        connection.Dispose();
                        connection = _connections[_redisConfiguration.ConnectionString];
                    }
                }

                await connection.GetDatabase().PingAsync();

                return HealthCheckResult.Healthy();
            }
            catch (Exception ex)
            {
                _metrics.Measure.Counter.Increment(MetricsRegistry.SimpleCounter);
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
