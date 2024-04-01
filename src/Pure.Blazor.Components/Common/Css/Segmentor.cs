namespace Pure.Blazor.Components.Common.Css;

public static class Segmentor
{
    public static Stack<string> Segment(this string input, char separator)
    {
        var closingBracketStack = new Stack<char>();
        var parts = new Stack<string>();
        var lastPos = 0;

        for (var idx = 0; idx < input.Length; idx++)
        {
            var charValue = input[idx];

            if (closingBracketStack.Count == 0 && charValue == separator)
            {
                parts.Push(input.Substring(lastPos, idx - lastPos));
                lastPos = idx + 1;
                continue;
            }

            switch (charValue)
            {
                case '\\':
                    idx += 1;
                    break;
                case '(':
                    closingBracketStack.Push(')');
                    break;
                case '[':
                    closingBracketStack.Push(']');
                    break;
                case '{':
                    closingBracketStack.Push('}');
                    break;
                case ')':
                case ']':
                case '}':
                    if (closingBracketStack.Count > 0 && charValue == closingBracketStack.Peek())
                    {
                        closingBracketStack.Pop();
                    }

                    break;
            }
        }

        parts.Push(input[lastPos..]);

        return parts;
    }
}
