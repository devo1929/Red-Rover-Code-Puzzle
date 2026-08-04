namespace RedRoverPuzzle.Services;

public class DataWriter
{
    public void Write(string filename, Dictionary<string, object?> data, SortMethod sortMethod = SortMethod.Default)
    {
        var lines = GetLines(data, [], sortMethod);
        File.WriteAllLines(filename, lines);
    }

    private List<string> GetLines(Dictionary<string, object?> data, List<string> lines, SortMethod sortMethod, int indent = 0)
    {
        var keys = data.Keys.ToList();
        if(sortMethod == SortMethod.Alphabetical)
            keys = keys.OrderBy(k => k).ToList();
        foreach (var key in keys)
        {
            var value = data[key];
            lines.Add($"{new string(' ', indent)}- {key}");
            if (value is not null)
                GetLines((value as Dictionary<string, object?>)!, lines, sortMethod, indent + 2);
        }

        return lines;
    }
}

public enum SortMethod
{
    Default,
    Alphabetical,
}