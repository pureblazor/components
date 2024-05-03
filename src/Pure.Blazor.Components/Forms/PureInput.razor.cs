using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Forms.Validators;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Forms;

public static class InputTypeMap
{
    public static Dictionary<InputType, string> Map = new()
    {
        { InputType.Text, "text" },
        { InputType.Button, "button" },
        { InputType.Checkbox, "checkbox" },
        { InputType.Color, "color" },
        { InputType.Date, "date" },
        { InputType.DateTimeLocal, "datetime-local" },
        { InputType.Email, "email" },
        { InputType.File, "file" },
        { InputType.Hidden, "hidden" },
        { InputType.Image, "image" },
        { InputType.Month, "month" },
        { InputType.Number, "number" },
        { InputType.Password, "password" },
        { InputType.Radio, "radio" },
        { InputType.Range, "range" },
        { InputType.Reset, "reset" },
        { InputType.Search, "search" },
        { InputType.Submit, "submit" },
        { InputType.Tel, "tel" },
        { InputType.Time, "time" },
        { InputType.Url, "url" },
        { InputType.Week, "week" }
    };
}

public static class InputAutoFillMap
{
    public static Dictionary<InputAutoFill, string> Map = new Dictionary<InputAutoFill, string>
    {
        { InputAutoFill.None, "none" },
        { InputAutoFill.Off, "off" },
        { InputAutoFill.On, "on" },
        { InputAutoFill.Name, "name" },
        { InputAutoFill.HonorificPrefix, "honorific-prefix" },
        { InputAutoFill.GivenName, "given-name" },
        { InputAutoFill.AdditionalName, "additional-name" },
        { InputAutoFill.FamilyName, "family-name" },
        { InputAutoFill.HonorificSuffix, "honorific-suffix" },
        { InputAutoFill.Nickname, "nickname" },
        { InputAutoFill.Email, "email" },
        { InputAutoFill.Username, "username" },
        { InputAutoFill.NewPassword, "new-password" },
        { InputAutoFill.CurrentPassword, "current-password" },
        { InputAutoFill.OrganizationTitle, "organization-title" },
        { InputAutoFill.Organization, "organization" },
        { InputAutoFill.StreetAddress, "street-address" },
        { InputAutoFill.AddressLine1, "address-line1" },
        { InputAutoFill.AddressLine2, "address-line2" },
        { InputAutoFill.AddressLine3, "address-line3" },
        { InputAutoFill.AddressLevel4, "address-level4" },
        { InputAutoFill.AddressLevel3, "address-level3" },
        { InputAutoFill.AddressLevel2, "address-level2" },
        { InputAutoFill.AddressLevel1, "address-level1" },
        { InputAutoFill.Country, "country" },
        { InputAutoFill.CountryName, "country-name" },
        { InputAutoFill.PostalCode, "postal-code" },
        { InputAutoFill.CCName, "cc-name" },
        { InputAutoFill.CCCSC, "cc-csc" },
        { InputAutoFill.CCExp, "cc-exp" },
        { InputAutoFill.CCExpMonth, "cc-exp-month" },
        { InputAutoFill.CCExpYear, "cc-exp-year" },
        { InputAutoFill.CCToken, "cc-token" },
        { InputAutoFill.TransactionCurrency, "transaction-currency" },
        { InputAutoFill.TransactionAmount, "transaction-amount" },
        { InputAutoFill.Language, "language" },
        { InputAutoFill.Bday, "bday" },
        { InputAutoFill.BdayDay, "bday-day" },
        { InputAutoFill.BdayMonth, "bday-month" },
        { InputAutoFill.BdayYear, "bday-year" },
        { InputAutoFill.Sex, "sex" },
        { InputAutoFill.URL, "url" },
        { InputAutoFill.Photo, "photo" }
    };
}

/// <summary>
/// Input autofill values
/// https://html.spec.whatwg.org/multipage/form-control-infrastructure.html#autofilling-form-controls:-the-autocomplete-attribute
/// </summary>
[Flags]
public enum InputAutoFill
{
    None,
    Off,
    On,
    Name,
    HonorificPrefix,
    GivenName,
    AdditionalName,
    FamilyName,
    HonorificSuffix,
    Nickname,
    Email,
    Username,
    NewPassword,
    CurrentPassword,
    OrganizationTitle,
    Organization,
    StreetAddress,
    AddressLine1,
    AddressLine2,
    AddressLine3,
    AddressLevel4,
    AddressLevel3,
    AddressLevel2,
    AddressLevel1,
    Country,
    CountryName,
    PostalCode,
    CCName,
    CCCSC,
    CCExp,
    CCExpMonth,
    CCExpYear,
    CCToken,
    TransactionCurrency,
    TransactionAmount,
    Language,
    Bday,
    BdayDay,
    BdayMonth,
    BdayYear,
    Sex,
    URL,
    Photo
}

public partial class PureInput
{
    private InputText? InputRef { get; set; } = null!;
    private readonly Guid guid = Guid.NewGuid();
    private readonly List<IEntryValidator> validators = new();

    private string baseCss =
        "peer block px-2 py-1 border-1 focus:outline focus:outline-2 focus:outline-offset-2 outline-brand-700 text-gray-800 rounded-md";

    private string defaultBorder = "border-gray-200";
    private string errorBorder = "border-red-600";
    private string? errorMessage;
    private string value = string.Empty;

    // the suffix needs different margins depending on labels and helper text
    private string suffixCss => GetSuffixCss();


    internal string Id => $"entry-{guid}";

    public PureSize Size { get; set; }

    [CascadingParameter] public PureForm? FormControl { get; set; }

    [Parameter] public InputAutoFill AutoComplete { get; set; }
    [Parameter] public InputType InputType { get; set; } = InputType.Text;

    /// <summary>
    ///     Defaults to immediate mode
    /// </summary>
    [Parameter]
    public EntryMode Mode { get; set; } = EntryMode.Immediate;

    [Parameter] public string? Name { get; set; }

    /// <summary>
    ///     Optional label (recommended)
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    ///     Optional label type
    /// </summary>
    [Parameter]
    public PureLabelType LabelType { get; set; }

    /// <summary>
    ///     Optional helper text
    /// </summary>
    [Parameter]
    public string? HelperText { get; set; }

    [Parameter] public EventCallback<string> ValueChanged { get; set; }

    /// <summary>
    ///     Makes the input required.
    /// </summary>
    [Parameter]
    public bool? Required { get; set; }

    /// <summary>
    ///     Enforces a minimum string length.
    /// </summary>
    [Parameter]
    public int? MinLength { get; set; }

    /// <summary>
    ///     Enforces a maximum string length.
    /// </summary>
    [Parameter]
    public int? MaxLength { get; set; }

    /// <summary>
    ///     Enforces a minimum for integers.
    /// </summary>
    [Parameter]
    public int? Min { get; set; }

    /// <summary>
    ///     Enforces a maximum for integers.
    /// </summary>
    [Parameter]
    public int? Max { get; set; }

    /// <summary>
    ///     Validates using the Regular Expression.
    /// </summary>
    [Parameter]
    public string? Regex { get; set; }

    [Parameter]
    public string? Placeholder { get; set; } =
        " "; // default placeholder to an empty string. required for floating labels.

    /// <summary>
    ///     Invoked when a validator indicates a validation error.
    /// </summary>
    [Parameter]
    public EventCallback<IList<ValidationResult>> OnError { get; set; }

    [Parameter] public RenderFragment? Suffix { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnSuffixClick { get; set; }
    [Parameter] public EventCallback<FocusEventArgs> OnBlur { get; set; }

    public async ValueTask FocusAsync()
    {
        if (InputRef?.Element is not null)
        {
            await InputRef.Element.Value.FocusAsync();
        }
    }

    public bool HasError { get; set; }

    [Parameter] public string? Value { get; set; }

    public void Validate(object? val)
    {
        var strValue = val?.ToString();
        var results = new List<ValidationResult>();
        foreach (var v in validators)
        {
            results.Add(v.Validate(strValue));
        }

        if (results.Any(p => !p.Valid))
        {
            HasError = true;
            errorMessage = results.First(p => !p.Valid).Message;
            OnError.InvokeAsync(results);
        }
        else
        {
            errorMessage = null;
            HasError = false;
        }
    }

    protected override void OnInitialized()
    {
        value = Value ?? string.Empty;

        if (Required == true)
        {
            validators.Add(new RequiredValidator());
        }

        if (MinLength.HasValue)
        {
            validators.Add(new MinLengthValidator(MinLength.Value));
        }

        if (MaxLength.HasValue)
        {
            validators.Add(new MaxLengthValidator(MaxLength.Value));
        }

        if (!string.IsNullOrWhiteSpace(Regex))
        {
            validators.Add(new RegexValidator(new Regex(Regex)));
        }

        if (Min.HasValue)
        {
            validators.Add(new MinMaxValidator(Min.Value, Max));
        }

        FormControl?.AddControl(this);
    }

    public async Task OnChange(ChangeEventArgs args)
    {
        // pass in args value, the Value property is not updated at this point
        Validate(args.Value);
        await ValueChanged.InvokeAsync(args.Value?.ToString() ?? string.Empty);
    }

    public async Task OnInput(ChangeEventArgs args)
    {
        if (Mode != EntryMode.Immediate)
        {
            return;
        }

        // pass in args value, the Value property is not updated at this point
        Validate(args.Value);
        await ValueChanged.InvokeAsync(args.Value?.ToString() ?? string.Empty);
    }

    private string GetInputType()
    {
        return InputTypeMap.Map[InputType];
    }

    private string GetAutoComplete()
    {
        return AutoComplete == InputAutoFill.None ? "" : InputAutoFillMap.Map[AutoComplete];
    }

    private string GetSuffixCss()
    {
        if (!string.IsNullOrWhiteSpace(Label) && LabelType != PureLabelType.Floating &&
            string.IsNullOrWhiteSpace(HelperText))
        {
            return "mt-9";
        }

        if (LabelType == PureLabelType.Floating &&
            (!string.IsNullOrWhiteSpace(HelperText) || !string.IsNullOrWhiteSpace(errorMessage)))
        {
            return "-mt-8";
        }

        return string.Empty;
    }
}
