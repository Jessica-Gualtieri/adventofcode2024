/* Part One
using System.Text.RegularExpressions;

string fileName = "input.txt";
string currentDirectory = AppContext.BaseDirectory;
string filePath = Path.Combine(currentDirectory, fileName);
StreamReader streamReader = new StreamReader(filePath);
string? line;
int total = 0;
string pattern = @"mul\(\d{1,3},\d{1,3}\)";


while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    MatchCollection matchCollection = Regex.Matches(line, pattern);
    foreach (Match match in matchCollection)
    {
        string separator = ",";
        int indexOfSeparator = match.Value.IndexOf(separator);
        if (indexOfSeparator > 0 && match.Value.Length > 6)
        {
            string firstValueAsString = match.Value.Substring(4, indexOfSeparator - 4);
            int firstValue = 0;
            if (int.TryParse(firstValueAsString, out _))
            {
                firstValue = int.Parse(firstValueAsString);
            }
            string secondValueAsString = match.Value.Substring(indexOfSeparator + 1, match.Value.Length - firstValueAsString.Length - 6);
            int secondValue = 0;
            if (int.TryParse(secondValueAsString, out _))
            {
                secondValue = int.Parse(secondValueAsString);
            }
            total += firstValue * secondValue;
        }
    }
}

Console.WriteLine(total);
*/

// Part Two
using System.Text.RegularExpressions;

string fileName = "input.txt";
string currentDirectory = AppContext.BaseDirectory;
string filePath = Path.Combine(currentDirectory, fileName);
StreamReader streamReader = new StreamReader(filePath);
string? line;
int total = 0;
string pattern = @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)";
bool doCondition = true;

while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
    MatchCollection matchCollection = Regex.Matches(line, pattern);
    foreach (Match match in matchCollection)
    {
        if (match.Value == "do()")
        {
            doCondition = true;
        }
        else if (match.Value == "don't()")
        {
            doCondition = false;
        }
        else if (doCondition)
        {
            string separator = ",";
            int indexOfSeparator = match.Value.IndexOf(separator);
            if (indexOfSeparator > 0 && match.Value.Length > 6)
            {
                string firstValueAsString = match.Value.Substring(4, indexOfSeparator - 4);
                int firstValue = 0;
                if (int.TryParse(firstValueAsString, out _))
                {
                    firstValue = int.Parse(firstValueAsString);
                }

                string secondValueAsString = match.Value.Substring(indexOfSeparator + 1,
                    match.Value.Length - firstValueAsString.Length - 6);
                int secondValue = 0;
                if (int.TryParse(secondValueAsString, out _))
                {
                    secondValue = int.Parse(secondValueAsString);
                }

                total += firstValue * secondValue;
            }
        }
    }
}

Console.WriteLine(total);