namespace Pure.Blazor.Components;

internal class FlexMap
{
    internal const string Row = "flex-row";
    internal const string RowReverse = "flex-row-reverse";
    internal const string Column = "flex-col";
    internal const string ColumnReverse = "flex-col-reverse";

    internal static FlexDirection GetFlexDirection(string value)
    {
        return value switch
        {
            Row => FlexDirection.Row,
            RowReverse => FlexDirection.RowReverse,
            Column => FlexDirection.Col,
            ColumnReverse => FlexDirection.ColReverse,
            _ => FlexDirection.Row
        };
    }

    internal static string GetFlexDirection(FlexDirection value)
    {
        return value switch
        {
            FlexDirection.Row => Row,
            FlexDirection.RowReverse => RowReverse,
            FlexDirection.Col => Column,
            FlexDirection.ColReverse => ColumnReverse,
            _ => Row
        };
    }

    internal static string GetAlignContent(FlexAlignContent value)
    {
        return value switch
        {
            FlexAlignContent.Start => "content-start",
            FlexAlignContent.End => "content-end",
            FlexAlignContent.Center => "content-center",
            FlexAlignContent.Between => "content-between",
            FlexAlignContent.Around => "content-around",
            FlexAlignContent.Evenly => "content-evenly",
            _ => "content-stretch"
        };
    }

    internal static string GetAlignItems(FlexAlignItems value)
    {
        return value switch
        {
            FlexAlignItems.Start => "items-start",
            FlexAlignItems.End => "items-end",
            FlexAlignItems.Center => "items-center",
            FlexAlignItems.Baseline => "items-baseline",
            FlexAlignItems.Stretch => "items-stretch",
            _ => "items-stretch"
        };
    }

    internal static string GetJustifyContent(FlexJustifyContent value)
    {
        return value switch
        {
            FlexJustifyContent.Start => "justify-start",
            FlexJustifyContent.End => "justify-end",
            FlexJustifyContent.Center => "justify-center",
            FlexJustifyContent.Between => "justify-between",
            FlexJustifyContent.Around => "justify-around",
            FlexJustifyContent.Evenly => "justify-evenly",
            _ => "justify-stretch"
        };
    }
}

public enum FlexDirection
{
    Row,
    RowReverse,
    Col,
    ColReverse
}

public enum FlexWrap
{
    Wrap,
    WrapReverse,
    NoWrap
}

public enum FlexAlignItems
{
    Start,
    End,
    Center,
    Baseline,
    Stretch
}

public enum FlexAlignContent
{
    Start,
    End,
    Center,
    Between,
    Around,
    Evenly
}

public enum FlexJustifyContent
{
    Start,
    End,
    Center,
    Between,
    Around,
    Evenly
}

public enum FlexAlignSelf
{
    Auto,
    Start,
    End,
    Center,
    Stretch,
    Baseline
}

public enum FlexGrow
{
    Grow,
    Grow0
}

public enum FlexShrink
{
    Shrink,
    Shrink0
}
