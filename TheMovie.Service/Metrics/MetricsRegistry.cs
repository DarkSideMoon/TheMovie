using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Gauge;
using App.Metrics.Timer;

namespace TheMovie.Service.Metrics
{
    public class MetricsRegistry
    {
        public static CounterOptions SimpleCounter = new CounterOptions
        {
            Name = "Redis health check errors counter",
            Context = "HealtCheck",
            MeasurementUnit = Unit.Errors
        };

        public static GaugeOptions ServiceMemory = new GaugeOptions
        {
            Name = "Service process memory in MB",
            Context = "Service",
            MeasurementUnit = Unit.MegaBytes
        };

        public static TimerOptions MovieRequestTimer = new TimerOptions
        {
            Name = "Get movie timer",
            Context = "Request",
            MeasurementUnit = Unit.Requests,
            DurationUnit = TimeUnit.Milliseconds,
            RateUnit = TimeUnit.Milliseconds
        };
    }
}
