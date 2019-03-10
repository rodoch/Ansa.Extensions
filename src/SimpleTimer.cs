using System;
using System.Diagnostics;

namespace Ansa.Extensions
{
    /// <summary>
    /// A more elegant way of measuring elapsed time that wraps the <see cref="Stopwatch"/> class
    /// </summary>
    public class SimpleTimer : IDisposable
    {
        private readonly Stopwatch _stopwatch;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stopwatch"/> class and starts measuring elapsed time
        /// </summary>
        public SimpleTimer()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        /// <summary>
        /// Stops measuring elapsed time
        /// </summary>
        public void Dispose()
        {
            _stopwatch.Stop();
        }

        /// <summary>
        /// Gets the total elapsed time measured by the current instance
        /// </summary>
        public TimeSpan Elapsed => _stopwatch.Elapsed;

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in milliseconds
        /// </summary>
        public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;

        /// <summary>
        /// Gets the total elapsed time measured by the current instance, in timer ticks
        /// </summary>
        public long ElapsedTicks => _stopwatch.ElapsedTicks;

        /// <summary>
        /// Gets a value indicating whether the <see cref="Stopwatch"/> timer is running
        /// </summary>
        public bool IsRunning => _stopwatch.IsRunning;

        /// <summary>
        /// Stops time interval measurement and resets the elapsed time to zero
        /// </summary>
        public void Reset() => _stopwatch.Reset();

        /// <summary>
        /// Stops time interval measurement, resets the elapsed time to zero, and starts measuring elapsed time
        /// </summary>
        public void Restart() => _stopwatch.Restart();

        /// <summary>
        /// Starts, or resumes, measuring elapsed time for an interval
        /// </summary>
        public void Start() => _stopwatch.Start();

        /// <summary>
        /// Stops measuring elapsed time for an interval
        /// </summary>
        public void Stop() => _stopwatch.Stop();
    }
}