string fileName = "input.txt";
string currentDirectory = AppContext.BaseDirectory;
string filePath = Path.Combine(currentDirectory, fileName);
StreamReader streamReader = new StreamReader(filePath);
string? line;
int total = 0;


while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    List<int> numbers = new List<int>();
    line += " "; // Use to prevent the following while loop from ignoring the last number

    while (line.Contains(' '))
    {
        int separatorIndex = line.IndexOf(' ');
        string numberAsString = line.Substring(0, separatorIndex);
        line = line.Remove(0, numberAsString.Length + 1);
        numbers.Add(int.Parse(numberAsString));
    }

    if (AllIsIncreasingOrDecreasingAtMin1AndMax3(numbers))
    {
        total++;
    }
}

Console.WriteLine(total);

bool AllIsIncreasingOrDecreasingAtMin1AndMax3(List<int> list)
{
    bool result = true;
    for (int i = 0; i < list.Count - 1; i++)
    {
        if (list[0] == list[1])
        {
            return false;
        } else if (list[0] < list[1])
        {
            result = list[i] < list[i + 1] && (list[i+1] - list[i] >= 1 && list[i+1] - list[i] <= 3);
        }
        else if (list[0] > list[1])
        {
            result = list[i] > list[i + 1] && (list[i] - list[i+1] >= 1 && list[i] - list[i+1] <= 3);
        }

        if (!result)
        {
            break;
        }
    }
    return result;
}

// Comment : seems to be a very complicated way to achieve the problem + the method is way too heavy, should (must) be simplified.