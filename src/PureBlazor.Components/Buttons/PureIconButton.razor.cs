using Microsoft.AspNetCore.Components;
using PureBlazor.Components.Icons;
using PureBlazor.Components.Styling;

namespace PureBlazor.Components;

public partial class PureIconButton
{
    [Parameter]
    public PureIcons Icon { get; set; }

    public override string BuildCss()
    {
        var builder = TailwindBuilder.New();

        switch (Variant)
        {
            case ButtonVariant.Filled:
                builder.AddBackground(Color).AddClasses("text-white");
                builder.AddBackgroundHover(Color.Eight);
                break;

            case ButtonVariant.Outline:
                builder.AddBorder(Color).SetFontColor(Color);
                break;

            case ButtonVariant.Default:
                builder.AddBorder(PureColor.Neutral).SetFontColor(PureColor.Neutral.Six);
                break;

            case ButtonVariant.Subtle:
                builder.AddBackgroundHover(Color.Two).SetFontColor(Color);
                break;

            default:
                break;
        }

        builder.AddClasses("rounded-sm font-semibold");

        if (Disabled)
        {
            //builder.AddClasses("");
        }

        return builder.Build();
    }
}