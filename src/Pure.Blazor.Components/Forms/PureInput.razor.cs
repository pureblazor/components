using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components.Forms.Validators;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Forms;

public partial class PureInput
{
    private InputText? InputRef { get; set; } = null!;
    private readonly List<IEntryValidator> validators = new();

    private string baseCss =
        "peer block px-2 py-1 border-1 focus:outline focus:outline-2 focus:outline-offset-2 outline-brand-700 bg-gray-50 text-gray-800 rounded";

    private string defaultBorder = "border-gray-200";
    private string errorBorder = "border-red-600";
    private string? errorMessage;
    private string value = string.Empty;

    // the suffix needs different margins depending on labels and helper text
    private string suffixCss => GetSuffixCss();

    public PureSize Size { get; set; }

    [CascadingParameter] public PureForm? FormControl { get; set; }

    [Parameter] public InputAutoComplete AutoComplete { get; set; }
    [Parameter] public InputType InputType { get; set; } = InputType.Text;

    /// <summary>
    ///     Defaults to immediate mode
    /// </summary>
    [Parameter]
    public EntryMode Mode { get; set; } = EntryMode.Immediate;

    /// <summary>
    ///     Optional label type
    /// </summary>
    [Parameter]
    public PureLabelType LabelType { get; set; }

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
        return AutoComplete == InputAutoComplete.None ? "off" : InputAutoFillMap.Map[AutoComplete];
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
