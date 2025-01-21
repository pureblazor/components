using Microsoft.JSInterop;

namespace Pure.Blazor.Components;

public class NoOpJsObjectReference : IJSObjectReference
{
    public ValueTask DisposeAsync() => ValueTask.CompletedTask;

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken,
        object?[]? args) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg0) =>
        new(default(TValue)!);

    public ValueTask<TValue>
        InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object? arg0) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg0, object? arg1) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object? arg0,
        object? arg1) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg0, object? arg1, object? arg2) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object? arg0,
        object? arg1, object? arg2) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg0, object? arg1, object? arg2,
        object? arg3) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object? arg0,
        object? arg1, object? arg2, object? arg3) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object? arg0, object? arg1, object? arg2,
        object? arg3, object? arg4) =>
        new(default(TValue)!);

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object? arg0,
        object? arg1, object? arg2, object? arg3, object? arg4) =>
        new(default(TValue)!);
}
