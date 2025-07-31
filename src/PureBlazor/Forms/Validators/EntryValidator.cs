namespace PureBlazor.Components;

internal abstract class EntryValidator : IEntryValidator
{
    protected ValidationResult? Valid;
    protected string? Input;

    public ValidationResult IsValid(string? input)
    {
        if (Valid != null && input == Input)
        {
            return Valid;
        }

        return Validate(input);
    }

    public ValidationResult Validate(string? input)
    {
        Input = input;
        Valid = ExecuteValidate(input);

        return Valid;
    }

    public abstract ValidationResult ExecuteValidate(string? input);
}
