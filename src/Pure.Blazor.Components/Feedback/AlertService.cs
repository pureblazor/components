using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Feedback;

public class AlertService(ILogger<AlertService> log) : IDisposable
{
    private ConcurrentDictionary<Guid, PeriodicTimer> timers = [];
    public Action<Alert>? OnChange { get; set; }

    internal List<Alert> Messages { get; set; } = [];

    public async Task ShowAsync(string message, Accent state = Accent.Default) =>
        await ShowAsync(new Alert(message, state));

    public Task ShowAsync(Alert alert)
    {
        log.LogDebug("Adding toast {toast}", alert);

        Messages.Add(alert);

        OnChange?.Invoke(alert);

        // don't wait for the remove to fire
#pragma warning disable CS4014
        Remove(alert, alert.Duration);
#pragma warning restore CS4014

        return Task.CompletedTask;
    }

    private async Task Remove(Alert alert, int removeInMs)
    {
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(removeInMs));
        timers.TryAdd(alert.AlertId, timer);
        while (await timer.WaitForNextTickAsync() && Messages.Contains(alert))
        {
            log.LogDebug("Removing toast {toast}", alert);
            await BeginRemove(alert);
        }

        timer.Dispose();
        timers.Remove(alert.AlertId, out _);
    }

    internal async Task RemoveImmediately(Alert alert)
    {
        log.LogDebug("Removing toast {toast}", alert);
        await BeginRemove(alert);
    }

    private async Task BeginRemove(Alert alert)
    {
        if (alert.IsRemoving || !Messages.Contains(alert))
        {
            return;
        }

        // mark the toast as removing so the UI has a chance
        // to make it disappear nicely
        alert.IsRemoving = true;
        OnChange?.Invoke(alert);

        // start a timer to remove the toast a few seconds after the UI can
        // fade it out
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(2000));
        timers.TryAdd(alert.AlertId, timer);
        while (await timer.WaitForNextTickAsync() && Messages.Contains(alert))
        {
            // actually remove the toast
            Messages.Remove(alert);
            OnChange?.Invoke(alert);
        }

        timer.Dispose();
        timers.TryRemove(alert.AlertId, out _);
    }

    public void Dispose()
    {
        Messages.Clear();
        foreach (var timer in timers.Values)
        {
            timer.Dispose();
        }
    }
}

public class Alert
{
    public Alert(string message, Accent state = Accent.Default, int duration = 5 * 1000)
    {
        Message = message;
        State = state;
        Duration = duration;
    }

    public Guid AlertId { get; } = Guid.NewGuid();

    /// <summary>
    ///     How long the toast should be visible before beginning to disappear.
    /// </summary>
    public int Duration { get; }

    /// <summary>
    ///     The text message content of the toast.
    /// </summary>
    public string Message { get; }

    /// <summary>
    ///     The state of the toast, e.g. success, info, danger.
    /// </summary>
    public Accent State { get; }

    /// <summary>
    ///     Flag indicating the toast is being removed. Used for the UI to know to begin transitioning
    ///     this out of the UI (disappearing).
    /// </summary>
    internal bool IsRemoving { get; set; }
}
