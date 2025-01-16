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
        Console.WriteLine(match.Value);
    }
}

Console.WriteLine(total);