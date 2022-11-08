namespace ITPrime;

public class FindGoodNumbersCommand
{
    public string[] Dictionary { get; private set; }

    public FindGoodNumbersCommand(string[] dictionary) 
    {
        Dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
    }
}
