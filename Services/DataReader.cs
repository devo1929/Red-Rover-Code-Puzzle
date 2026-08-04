namespace RedRoverPuzzle.Services;

public class DataReader
{
    private const string DataFile = "Data/input.txt";
    public string Read() => File.ReadAllText(DataFile);
}