using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Pure.Blazor.Components;

public partial class Sheet
{
    [Parameter] public bool IsOpen { get; set; }

    [Parameter] public RenderFragment? SheetHeader { get; set; }

    [Parameter] public RenderFragment? SheetContent { get; set; }

    [Parameter] public RenderFragment? SheetFooter { get; set; }

    [Parameter] public EventCallback<bool> IsOpenChanged { get; set; }

    [Parameter] public EventCallback OnDismiss { get; set; }

    private ElementReference? dismissButton;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        // when the flyout is opened for the first time, we want to focus the dismiss button
        if (parameters.TryGetValue<bool>(nameof(IsOpen), out var isOpen) && isOpen && !IsOpen)
        {
            await base.SetParametersAsync(parameters);
            await FocusDismissButtonAsync();
        }
        else
        {
            await base.SetParametersAsync(parameters);
        }
    }

    private async Task HandleKeyDown(KeyboardEventArgs e)
    {
        // Only dismiss if the sheet is open and the Esc key is pressed
        if (IsOpen && e.Key == "Escape")
        {
            await Dismiss();
        }
    }

    private async Task FocusDismissButtonAsync()
    {
        if (dismissButton is not null)
        {
            await dismissButton.Value.FocusAsync();
        }
    }

    public async Task Dismiss()
    {
        IsOpen = false;
        await OnDismiss.InvokeAsync();
        await IsOpenChanged.InvokeAsync(IsOpen);
    }

    /// <summary>
    /// Which edge of the screen should the sheet slide from?
    /// </summary>
    public enum SheetPosition
    {
        Left,
        Right,
        Top,
        Bottom
    }

    /// <summary>
    /// Defaults to sliding in from the right.
    /// </summary>
    [Parameter]
    public SheetPosition Position { get; set; } = SheetPosition.Right;

    /// <summary>
    /// Position-related classes for the outer container.
    /// This determines where the sheet is anchored in the viewport.
    /// </summary>
    private string ContainerPositionClass => Position switch
    {
        SheetPosition.Left   => "inset-y-0 left-0 flex max-w-full pr-10 sm:pr-16",
        SheetPosition.Right  => "inset-y-0 right-0 flex max-w-full pl-10 sm:pl-16",
        SheetPosition.Top    => "inset-x-0 top-0 flex max-h-full pb-10 sm:pb-16",
        SheetPosition.Bottom => "inset-x-0 bottom-0 flex max-h-full pt-10 sm:pt-16",
        _                    => "inset-y-0 right-0 flex max-w-full pl-10 sm:pl-16"
    };

    /// <summary>
    /// Classes applied when the sheet is open (transform is reset).
    /// </summary>
    private string OpenTransformClass => Position switch
    {
        SheetPosition.Left   => "translate-x-0",
        SheetPosition.Right  => "translate-x-0",
        SheetPosition.Top    => "translate-y-0",
        SheetPosition.Bottom => "translate-y-0",
        _                    => "translate-x-0"
    };

    /// <summary>
    /// Classes applied when the sheet is closed (shifted fully out of view).
    /// </summary>
    private string ClosedTransformClass => Position switch
    {
        SheetPosition.Left   => "-translate-x-full",
        SheetPosition.Right  => "translate-x-full",
        SheetPosition.Top    => "-translate-y-full",
        SheetPosition.Bottom => "translate-y-full",
        _                    => "translate-x-full"
    };

    private string SizeClass => Position switch
    {
        SheetPosition.Left => "w-screen h-full max-h-full max-w-96",
        SheetPosition.Right => "w-screen h-full max-h-full max-w-96",
        SheetPosition.Top => "h-screen w-full max-w-full max-h-96",
        SheetPosition.Bottom => "h-screen w-full max-w-full max-h-96",
        _ => ""
    };
}
