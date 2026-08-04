using RedRoverPuzzle.Services;

class Program
{
    public static void Main() => new Program().Run();

    private readonly DataParser _dataParser = new();
    private readonly DataReader _dataReader = new();
    private readonly DataWriter _dataWriter = new();

    private void Run()
    {
        var content = _dataReader.Read();
        var data = _dataParser.Parse(content);
        _dataWriter.Write("output.txt", data);
        _dataWriter.Write("output-sorted.txt", data, SortMethod.Alphabetical);
    }
}