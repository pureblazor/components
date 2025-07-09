namespace PureBlazor.Components;

internal interface IFormComponent
{
    object? Value { get; set; }
    bool HasError { get; set; }
    void Validate(object? val);
}
