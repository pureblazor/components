using System.Text.RegularExpressions;

namespace Pure.Blazor.Components.Forms.Validators;

internal class RegexValidator : EntryValidator
{
    private readonly Regex _rx;

    public RegexValidator(Regex rx)
    {
        _rx = rx;
    }

    public override ValidationResult ExecuteValidate(string? input)
    {
        if (input == null)
        {
            return new ValidationResult(true);
        }

        var match = _rx.Match(input);
        var success = match.Success && match.Value.Length == input.Length;
        return new ValidationResult(success, success == false ? $"{input} does not match the regular expression" : null);
    }
}
