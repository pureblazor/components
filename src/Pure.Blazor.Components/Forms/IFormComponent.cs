namespace Pure.Blazor.Components;

internal interface IFormComponent
{
    string? Value { get; set; }
    bool HasError { get; set; }
    void Validate(object? val);
}
