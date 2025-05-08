namespace Pure.Blazor.Components;

public class ButtonVariants
{
    public static readonly Pb Default = new()
    {
        Base = "inline-flex items-center justify-center font-medium transition-colors focus:outline-none disabled:opacity-50 disabled:pointer-events-none",

        VariantsByCategory = new Dictionary<string, Dictionary<string, string>>
        {
            // 1) Category: "variant"
            ["variant"] = new()
            {
                ["primary"] = "bg-primary/90 hover:bg-primary/80 text-primary-foreground cursor-pointer active:bg-primary",
                ["secondary"] = "bg-secondary hover:bg-secondary/80 text-secondary-foreground cursor-pointer",
                ["destructive"] = "bg-destructive hover:bg-destructive/80 text-destructive-foreground cursor-pointer",
                ["outline"] = "bg-transparent border border-primary/20 hover:bg-primary/20 text-secondary-foreground cursor-pointer",
                ["ghost"] = "bg-transparent hover:bg-primary/10 text-secondary-foreground cursor-pointer",
            },

            // 2) Category: "size"
            ["size"] = new()
            {
                ["sm"] = "h-8 px-3 rounded-md text-sm",
                ["lg"] = "h-10 px-5 rounded-md text-base",
            },
        }
    };
}

public class LinkVariants
{
    public static readonly Pb Default = new()
    {
        Base = "inline-flex items-center justify-center font-medium transition-colors focus:outline-none disabled:opacity-50 disabled:pointer-events-none",

        VariantsByCategory = new Dictionary<string, Dictionary<string, string>>
        {
            // 1) Category: "variant"
            ["variant"] = new()
            {
                ["primary"] = "bg-primary/90 hover:bg-primary/80 text-primary-foreground cursor-pointer active:bg-primary",
                ["secondary"] = "bg-secondary hover:bg-secondary/80 text-secondary-foreground cursor-pointer",
                ["destructive"] = "bg-destructive hover:bg-destructive/80 text-destructive-foreground cursor-pointer",
                ["outline"] = "bg-transparent border border-primary/20 hover:bg-primary/20 text-secondary-foreground cursor-pointer",
                ["ghost"] = "bg-transparent hover:bg-primary/10 text-secondary-foreground cursor-pointer",
                ["link"] = "text-primary underline-offset-4 hover:underline -mx-3",
            },

            // 2) Category: "size"
            ["size"] = new()
            {
                ["sm"] = "h-8 px-3 rounded-md text-sm",
                ["lg"] = "h-10 px-5 rounded-md text-base",
            },
        }
    };
}
