using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace PureBlazor.Components.Utilities;
public class NamingUtils
{
    private readonly static char[] AcceptableCharacters = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
    private const int DefaultRandomLength = 8;
    private static readonly Random randomGenerator = new Random();
    private static readonly object mutexLock = new object();
    private static readonly HashSet<string> previouslyUsedRandom = new HashSet<string>();
    
    public static string CreateRandomizedId()
    {
        return CreateRandomizedId(DefaultRandomLength);
    }
    
    public static string CreateRandomizedId(int length)
    {
        if (length < 0)
        {
            return "";
        }
        
        lock (mutexLock)
        {
            int startIndex = 0;
            char[] randomizedChars = new char[length];

            while (startIndex < length)
            {
                randomizedChars[startIndex] = AcceptableCharacters[randomGenerator.Next(AcceptableCharacters.Length)];
                startIndex++;
            }
            
            return new String(randomizedChars);
        }
    }
}
