string fileName = "input.txt";
string currentDirectory = AppContext.BaseDirectory;
string filePath = Path.Combine(currentDirectory, fileName);
StreamReader streamReader = new StreamReader(filePath);
string? line;
int total = 0;


while (!streamReader.EndOfStream)
{
    line = streamReader.ReadLine();
}

Console.WriteLine(total);