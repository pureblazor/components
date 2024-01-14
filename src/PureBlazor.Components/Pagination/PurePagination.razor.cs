using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using PureBlazor.Components.Styling;
using System.Drawing;

namespace PureBlazor.Components.Pagination;

public partial class PurePagination
{
    /// <summary>
    /// Inner content for the dropdown button.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }


    ///<summary>
    /// Total number of pages.
    ///</summary>
    [Parameter]
    public int Total { get; set; } = 0;

    ///<summary>
    /// Current page number.
    ///</summary>
    [Parameter]
    public int Current { get; set; } = 0;


    ///<summary>
    /// Helper Field to get the First Page
    ///</summary>
    internal int FirstPage => 1;

    ///<summary>
    /// Helper Field to get the Previous Page
    ///</summary>
    internal int PreviousPage => Current - 1;
    ///<summary>
    /// Helper Field to get the Next Page
    ///</summary>
    internal int NextPage => Current + 1;
    ///<summary>
    /// Helper Field to get the Last Page
    ///</summary>
    internal int LastPage => Total;

    ///<summary>
    /// Number of items to display to the left and right of the current page.
    ///</summary>
    [Parameter]
    public int Siblings { get; set; } = 3;

    ///<summary>
    /// Helper Field to get the First Sibling
    ///</summary>
    internal int FirstSibling => Math.Max(Current - Siblings, FirstPage);

    ///<summary>
    /// Helper Field to get the Last Sibling
    ///</summary>
    internal int LastSibling => Math.Min(Current + Siblings, LastPage);

    ///<summary>
    /// When True, Enables the controls for jumping to the First/Last Pages
    ///</summary>
    [Parameter]
    public bool EdgeControls { get; set; } = false;

    ///<summary>
    /// Callback with the page number clicked on.
    ///</summary>
    [Parameter]
    public EventCallback<int> OnChange { get; set; }
}
