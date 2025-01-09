/* Part One
string fileName = "input.txt";
string currentDirectory = AppContext.BaseDirectory;
string filePath = Path.Combine(currentDirectory, fileName);
StreamReader streamReader = new StreamReader(filePath);
string? line;
int total = 0;
List<int> leftColumn = new List<int>();
List<int> rightColumn = new List<int>();


while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    int separatorIndex = line.IndexOf(' ');
    string leftNumberAsString = line.Substring(0, separatorIndex);
    string rightNumberAsString = line.Substring(separatorIndex+1);
    ConvertToIntAndAddToList(leftNumberAsString, leftColumn);
    ConvertToIntAndAddToList(rightNumberAsString, rightColumn);
}

int listCount = leftColumn.Count;
for (int i = 0; i < listCount; i++)
{
    int smallestNumberFromLeftColumn = GetSmallestNumber(leftColumn);
    int smallestNumberFromRightColumn = GetSmallestNumber(rightColumn);
    total += smallestNumberFromLeftColumn >= smallestNumberFromRightColumn ? smallestNumberFromLeftColumn - smallestNumberFromRightColumn : smallestNumberFromRightColumn -
        smallestNumberFromLeftColumn;
    leftColumn.Remove(smallestNumberFromLeftColumn);
    rightColumn.Remove(smallestNumberFromRightColumn);
}

Console.WriteLine(total);


void ConvertToIntAndAddToList(string numberAsString, List<int> list)
{
    int number = int.Parse(numberAsString);
    list.Add(number);
}

int GetSmallestNumber(List<int> list)
{
    int smallestNumber = 0;
    smallestNumber = list.Min();
    return smallestNumber;
}
*/

// Part Two
string fileName = "input.txt";
string currentDirectory = AppContext.BaseDirectory;
string filePath = Path.Combine(currentDirectory, fileName);
StreamReader streamReader = new StreamReader(filePath);
string? line;
int total = 0;
List<int> leftColumn = new List<int>();
List<int> rightColumn = new List<int>();


while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    int separatorIndex = line.IndexOf(' ');
    string leftNumberAsString = line.Substring(0, separatorIndex);
    string rightNumberAsString = line.Substring(separatorIndex+1);
    ConvertToIntAndAddToList(leftNumberAsString, leftColumn);
    ConvertToIntAndAddToList(rightNumberAsString, rightColumn);
}

foreach (int number in leftColumn)
{
    List<int> list = rightColumn.FindAll(x => x == number);
    total += list.Count > 0 ? list.Count * number : 0;
}

Console.WriteLine(total);

void ConvertToIntAndAddToList(string numberAsString, List<int> list)
{
    int number = int.Parse(numberAsString);
    list.Add(number);
}