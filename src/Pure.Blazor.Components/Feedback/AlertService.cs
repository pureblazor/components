using Microsoft.Extensions.Logging;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Feedback;

public class AlertService
{
    private readonly ILogger<AlertService> _log;

    public AlertService(ILogger<AlertService> log) => _log = log;

    public Action<Alert>? OnChange { get; set; }

    internal List<Alert> Messages { get; set; } = new();

    public async Task ShowAsync(string message, Accent state = Accent.Default) =>
        await ShowAsync(new Alert(message, state));

    public Task ShowAsync(Alert alert)
    {
        _log.LogInformation("Adding toast {toast}", alert);

        Messages.Add(alert);

        OnChange?.Invoke(alert);

        // don't wait for the remove to fire
#pragma warning disable CS4014
        Remove(alert, alert.Duration);
#pragma warning restore CS4014

        return Task.CompletedTask;
    }

    internal async Task Remove(Alert alert, int removeInMs)
    {
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(removeInMs));

        while (await timer.WaitForNextTickAsync())
        {
            _log.LogInformation("Removing toast {toast}", alert);
            await BeginRemove(alert);
        }
    }

    private async Task BeginRemove(Alert alert)
    {
        // mark the toast as removing so the UI has a chance
        // to make it disappear nicely
        alert.IsRemoving = true;
        OnChange?.Invoke(alert);

        // start a timer to remove the toast a few seconds after the UI can
        // fade it out
        var timer = new PeriodicTimer(TimeSpan.FromMilliseconds(2000));
        while (await timer.WaitForNextTickAsync())
        {
            // actually remove the toast
            Messages.Remove(alert);
            OnChange?.Invoke(alert);
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
