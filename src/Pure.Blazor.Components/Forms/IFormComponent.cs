namespace Pure.Blazor.Components.Forms;

internal interface IFormComponent
{
    object? Value { get; set; }
    bool HasError { get; set; }
    void Validate(object? val);
}
