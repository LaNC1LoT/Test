using ITPrime;

//var command = new FindGoodNumbersCommand(new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C" });
//var service = new FindGoodNumbersService(new Parser(), new Writer());

//service.Execute(command);

var number1 = new long[] { 0, 2 };
var number2 = new long[] { 0, 1 };

var result = BigNumbers.Sum(number1, number2);

//result.ToList().ForEach(i => Console.Write($"{i}"));
//Console.WriteLine();

List<long[]> oddNumbers = new(); // коллекция для ничётных индексов
List<long[]> evenNumber = new(); // коллекция для чётных индексов


oddNumbers.Add(new long[] { 1 });
evenNumber.Add(new long[] { 2 });

long index = 3;
long[] lastNumber = null;

while (index <= 100000)
{
    if (index % 2 == 0)
    {
        lastNumber = BigNumbers.Sum(oddNumbers);
        AddNumber(evenNumber, lastNumber);
    }
    else 
    {
        lastNumber = BigNumbers.Sum(evenNumber);
        AddNumber(oddNumbers, lastNumber);
    }

    index++;
}

Console.WriteLine(BigNumbers.ToString(lastNumber));

//oddNumbers.ForEach(i => Console.Write(BigNumbers.ToString(i) + " "));
//Console.WriteLine();
//evenNumber.ForEach(i => Console.Write(BigNumbers.ToString(i) + " "));

static void AddNumber(List<long[]> collection, long[] number)
{ 
    if (collection.Count >= 13) collection.RemoveAt(0);
    collection.Add(number);
}

// F[1] = 1, F[2] = 2, F[3] = 2, F[4] = 3, F[5] = 5, F[6] = 8, F[7] = 13, F[8] = 21, F[9] = 34, F[10] = 55
// F[1] = 1 F[3] = 2 F[5] = 5 F[7] = 13 F[9] = 34
// F[2] = 2 F[4] = 3 F[6] = 8 F[8] = 21 F[10] = 55

/*
1 2 5 13 34
2 3 8 21 55
*/