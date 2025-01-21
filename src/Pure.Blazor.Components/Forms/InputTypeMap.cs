namespace Pure.Blazor.Components;

public static class InputTypeMap
{
    public static Dictionary<InputType, string> Map = new()
    {
        { InputType.Text, "text" },
        { InputType.Button, "button" },
        { InputType.Checkbox, "checkbox" },
        { InputType.Color, "color" },
        { InputType.Date, "date" },
        { InputType.DateTimeLocal, "datetime-local" },
        { InputType.Email, "email" },
        { InputType.File, "file" },
        { InputType.Hidden, "hidden" },
        { InputType.Image, "image" },
        { InputType.Month, "month" },
        { InputType.Number, "number" },
        { InputType.Password, "password" },
        { InputType.Radio, "radio" },
        { InputType.Range, "range" },
        { InputType.Reset, "reset" },
        { InputType.Search, "search" },
        { InputType.Submit, "submit" },
        { InputType.Tel, "tel" },
        { InputType.Time, "time" },
        { InputType.Url, "url" },
        { InputType.Week, "week" }
    };
}
