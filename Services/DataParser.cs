using System.Text.RegularExpressions;

namespace RedRoverPuzzle.Services;

public class DataParser
{
    // regex approach
    // private static readonly Regex Data = new(@"(?<field>\w+)(?:\((?<object>(?:[^()]*|(?<objectFields>\()|(?<-objectFields>\)))*(?(objectFields)(?!)))\))?");

    public Dictionary<string, object?> Parse(string content)
    {
        // strip all whitespace, remove opening parenthesis
        var chars = Regex.Replace(content, @"\s+", string.Empty)[1..].ToList();
        return ParseGroup(chars, new Dictionary<string, object?>());
    }

    private static Dictionary<string, object?> ParseGroup(List<char> chars, Dictionary<string, object?> data)
    {
        var field = string.Empty;
        while (chars.Count != 0)
        {
            var c = chars[0];
            chars.RemoveAt(0);
            switch (c)
            {
                case '(': // opening group
                    AddField(field, ParseGroup(chars, new Dictionary<string, object?>()), data);
                    field = string.Empty;
                    break;
                case ')': // closing group
                    AddField(field, null, data);
                    return data;
                case ',': // new field
                    AddField(field, null, data);
                    field = string.Empty;
                    break;
                default: // part of field
                    field += c;
                    break;
            }
        }

        return data;
    }

    private static void AddField(string key, object? value, Dictionary<string, object?> data)
    {
        if (string.IsNullOrEmpty(key)) return;
        data.Add(key, value);
    }
}