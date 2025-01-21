namespace Pure.Blazor.Components;

public class LeftNavStyles
{
    public string Container => "flex flex-col py-4 w-full gap-0.5";
    public string Header => "px-2 py-0.5 inline-block text-slate-700 hover:text-brand-900 antialiased font-medium font-sans leading-6 rounded-md bg-transparent";
    public string HeaderActive => "px-2 py-0.5 inline-block text-brand-700 hover:text-brand-900 antialiased font-bold font-sans leading-6 rounded-md bg-transparent";
    public string MenuItemContainer => "pl-4";
    public string MenuItem => "px-2 py-1 text-sm hover:text-brand-900";
    public string MenuItemActive => "font-bold text-brand-700";
}
