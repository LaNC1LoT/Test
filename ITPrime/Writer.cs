namespace ITPrime;

public class Writer : IWriter
{
    public void Write(string value)
    {
        Console.WriteLine(value);
    }
}