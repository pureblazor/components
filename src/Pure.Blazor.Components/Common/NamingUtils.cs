namespace Pure.Blazor.Components.Common;

public class NamingUtils
{
    private const int DefaultRandomLength = 8;

    private static readonly char[] AcceptableCharacters =
    [
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
        'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
    ];

    private static readonly Random randomGenerator = new();
    private static readonly object mutexLock = new();
    private static readonly HashSet<string> previouslyUsedRandom = new();

    public static string CreateRandomizedId() => CreateRandomizedId(DefaultRandomLength);

    public static string CreateRandomizedId(int length)
    {
        if (length < 0)
        {
            return "";
        }

        lock (mutexLock)
        {
            var startIndex = 0;
            var randomizedChars = new char[length];

            while (startIndex < length)
            {
                randomizedChars[startIndex] = AcceptableCharacters[randomGenerator.Next(AcceptableCharacters.Length)];
                startIndex++;
            }

            return new string(randomizedChars);
        }
    }
}
