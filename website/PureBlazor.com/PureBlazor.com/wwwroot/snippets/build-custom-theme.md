public record DefaultTheme : PureTheme
{
    public DefaultTheme()
    {
        ButtonDefaults.PressEffect = Effect.InsetShadow;
        ButtonDefaults.HoverEffect = Effect.Unset;
        StylePrioritizer = new StylePrioritizer();
        Styles = new Dictionary<string, ComponentStyle>
        {
            {
                nameof(PureButton),
                new ComponentStyle(ButtonStyles.Base, null, ButtonStyles.Variants, ButtonStyles.Sizes)
            },
            {
                nameof(PureIconButton),
                new ComponentStyle(ButtonStyles.Base, null, ButtonStyles.Variants, ButtonStyles.Sizes)
            },
            {
                nameof(PureDropdown),
                new ComponentStyle(DropdownStyles.Base, null, null, DropdownStyles.Sizes)
                {
                    InnerContainer = new ComponentStyle(DropdownStyles.Container.Base, null, null, null)
                }
            },
            {
                nameof(PureDropdownItem),
                new ComponentStyle(DropdownStyles.MenuItem.Base, DropdownStyles.MenuItem.Accents, null,
                    DropdownStyles.MenuItem.Sizes)
            },
            { nameof(PureBanner), new ComponentStyle(BannerStyles.Base, null, BannerStyles.Variants, null) },
            { nameof(PureLink), new ComponentStyle(LinkStyles.Base, null, null, null) },
            { nameof(PureBadge), new ComponentStyle("", null, BadgeStyles.Variants, null) },
            { nameof(PureAlert), new ComponentStyle(AlertStyles.Base, AlertStyles.Accents, null, null) },
            {
                nameof(PureColorIndicator),
                new ComponentStyle("", null, null, null)
                {
                    InnerContainer = new ComponentStyle("", IndicatorStyles.Background, null, null)
                    {
                        OuterContainer = new ComponentStyle("", IndicatorStyles.Foreground, null, null)
                    }
                }
            },
        };
    }
}
