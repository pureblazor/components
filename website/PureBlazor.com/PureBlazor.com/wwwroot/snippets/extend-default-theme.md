// Create a dictionary of customized variants for the PureButton component
var customizedVariants = new Dictionary<PureVariant, Dictionary<Accent, string>>
{
    {
        PureVariant.Default,
        new Dictionary<Accent, string>
        {
            {
                Accent.Brand,
                "bg-gradient-to-r from-indigo-500 via-purple-500 to-pink-500 hover:bg-gradient-to-l"
            },
            { Accent.Success, "bg-gradient-to-r from-brand-300 to-emerald-500 hover:bg-gradient-to-l" },
            {
                Accent.Danger,
                "bg-gradient-to-r from-orange-300 from-10% via-red-700 via-50% to-90% to-orange-700 hover:bg-gradient-to-l"
            },
            {
                Accent.Default,
                "bg-gradient-to-r from-green-400 to-blue-500 hover:from-pink-500 hover:to-yellow-500"
            }
        }
    }
};

// Get the existing style for the PureButton component so we can use it as a base
var existingStyle = theme.Styles[nameof(PureButton)];

// Bundle the customized variants into a dictionary of customized styles
var customizedStyles = new Dictionary<string, ComponentStyle>
{
    {
        nameof(PureButton),

        // Create a new ComponentStyle with the customized variants
        new ComponentStyle(existingStyle.Base, null, customizedVariants, existingStyle.Sizes)
    }
};

// merge the customized styles with the existing styles
demoTheme = theme with { Styles = customizedStyles };
