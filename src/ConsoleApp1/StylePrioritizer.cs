using System.Buffers;
using System.Collections.Concurrent;
using System.Text;
using BenchmarkDotNet.Attributes;
using ConsoleApp1;

public class TrieNode
{
    public bool IsEndOfWord { get; set; }
    public TrieNode?[] Children { get; set; } = new TrieNode?[128]; // ASCII value ranges from 0 to 127
}

public class Trie
{
    private readonly TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        var node = root;
        foreach (var ch in word)
        {
            var index = ch % 128; // ASCII value ranges from 0 to 127
            if (node.Children[index] == null)
            {
                node.Children[index] = new TrieNode();
            }

            node = node.Children[index]!;
        }

        node.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var node = root;
        foreach (var ch in word)
        {
            var index = ch % 128; // ASCII value ranges from 0 to 127
            node = node.Children[index]!;
            if (node == null)
            {
                return false;
            }
        }

        return node.IsEndOfWord;
    }
}

public class StylePrioritizer
{
    private Dictionary<string, string> userStylesDict = new Dictionary<string, string>();
    private string? lastUserStyles;

    [Benchmark]
    [Arguments(@"border-gray-100 bg-white text-gray-900", @"border-gray-200 hover:border-gray-300")]
    [Arguments(@"border-gray-100 bg-white text-gray-900 hover:text-gray-400 border-1 divide-y", @"border-gray-200 hover:border-gray-300 opacity-1 hover:opacity-0")]
    public string PrioritizeStyles(string defaultStyles, string userStyles)
    {
        if (userStyles != lastUserStyles)
        {
            userStylesDict.Clear();
            foreach (var style in userStyles.Split(' '))
            {
                userStylesDict[style] = style;
            }

            lastUserStyles = userStyles;
        }

        var result = new ValueStringBuilder(defaultStyles.Length + userStyles.Length);
        var buffer = ArrayPool<char>.Shared.Rent(defaultStyles.Length);

        try
        {
            defaultStyles.AsSpan().CopyTo(buffer);
            int start = 0;
            for (int i = 0; i < defaultStyles.Length; i++)
            {
                if (buffer[i] == ' ')
                {
                    var style = new string(buffer, start, i - start);
                    if (!userStylesDict.ContainsKey(style))
                    {
                        result.Append(style);
                        result.Append(' ');
                    }

                    start = i + 1;
                }
            }

            // Add the last style if it's not in user styles
            var lastStyle = new string(buffer, start, defaultStyles.Length - start);
            if (!userStylesDict.ContainsKey(lastStyle))
            {
                result.Append(lastStyle);
                result.Append(' ');
            }

            // Add all user styles
            result.Append(userStyles);

            return result.ToString();
        }
        finally
        {
            ArrayPool<char>.Shared.Return(buffer);
        }
    }
}
