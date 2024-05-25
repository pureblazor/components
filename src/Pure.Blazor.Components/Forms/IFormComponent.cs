namespace Pure.Blazor.Components.Forms;

internal interface IFormComponent
{
    string Value { get; set; }
    bool HasError { get; set; }
    void Validate(object? val);
}
