namespace ITPrime;

public class FindGoodNumbersService : ICommandService<FindGoodNumbersCommand>
{
    private IParser Parser { get; set; }
    private IWriter Writer { get; set; }

    public FindGoodNumbersService(IParser Parser, IWriter Writer)
    {
        this.Parser = Parser ?? throw new ArgumentNullException(nameof(Parser));
        this.Writer = Writer ?? throw new ArgumentNullException(nameof(Writer));
    }

    public void Execute(FindGoodNumbersCommand command)
    {
        long[] numbers = new long[command.Dictionary.Length];

        for (int i = 0; i < command.Dictionary.Length; i++) 
        {
            numbers[i] = Parser.Parse(command.Dictionary[i]);   
        }

        var crossJoinResult = from n1 in numbers
                              from n2 in numbers
                              from n3 in numbers
                              from n4 in numbers
                              from n5 in numbers
                              from n6 in numbers
                              select new { n1, n2, n3, n4, n5, n6, summary = n1 + n2 + n3 + n4 + n5 + n6 };

        var answer = crossJoinResult
            .GroupBy(i => i.summary)
            .Select(i => new { total = (Int64)i.Count() * (Int64)i.Count() * numbers.Length })
            .Sum(i => i.total);

        Writer.Write(answer.ToString());
    }
}
