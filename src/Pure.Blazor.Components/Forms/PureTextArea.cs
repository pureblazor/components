using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Pure.Blazor.Components.Essentials;

namespace Pure.Blazor.Components.Forms;

public class PureTextArea : PureInputBase
{
    private string currentValue = "";

    private string CurrentValue
    {
        get => currentValue;
        set
        {
            if (currentValue == value)
            {
                return;
            }

            currentValue = value;
            ValueChanged.InvokeAsync(value);
        }
    }

    /// <summary>
    /// Specifies the number of rows for the textarea.
    /// </summary>
    [Parameter]
    public int Rows { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "flex flex-col relative");

        if (!string.IsNullOrWhiteSpace(Label))
        {
            void LabelContent(RenderTreeBuilder b)
            {
                b.AddContent(0, Label);
            }

            builder.OpenRegion(2);
            builder.OpenComponent<PureLabel>(0);
            builder.AddComponentParameter(1, "For", Id);
            builder.AddComponentParameter(2, "ChildContent", (RenderFragment)LabelContent);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        builder.OpenRegion(10);
        builder.OpenElement(0, "textarea");
        builder.AddAttribute(1, "class",
            "peer block w-full px-2 py-1 border-1 border-gray-200 focus:outline focus:outline-2 focus:outline-offset-2 outline-brand-700 bg-gray-50 text-gray-800 rounded");
        builder.AddAttribute(2, "Id", Id);
        if (!string.IsNullOrWhiteSpace(Name))
        {
            builder.AddAttribute(3, "name", Name);
        }

        // initial value requires this to be set
        builder.AddAttribute(4, "value", Value);
        builder.AddAttribute(5, "rows", Rows);

        builder.AddAttribute(10, "oninput",
            EventCallback.Factory.CreateBinder<string>(this, (value => CurrentValue = value), CurrentValue));
        // builder.AddAttribute(11, "oninput",
        //     EventCallback.Factory.CreateBinder<string>(this, (value => CurrentValue = value), CurrentValue));

        builder.CloseElement();
        builder.CloseRegion();
        builder.CloseElement();
    }
}
