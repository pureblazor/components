namespace Pure.Blazor.Components;

public class DropdownMenuContainerStyles
{

    /// <remarks>
    /// - overflow-hidden: fixes issue where on hover the bottom rounded borders are not visible due to the square shape of the dropdown item
    /// </remarks>
    public string Base { get; set; } =
        "w-full origin-top-right ml-[1px] -mr-[1px] absolute overflow-hidden rounded-b-lg shadow-lg bg-white ring-1 ring-black/20 focus:outline-none invisible group-focus-within/dropdown:visible group-active/dropdown:visible z-10 font-medium";
}
