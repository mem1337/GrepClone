using GrepClone;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            string text = File.ReadAllText("TextFile");
            ScanText scanText = new ScanText(text);
            Console.WriteLine("What are you searching for: ");
            Console.WriteLine(scanText.Search(Console.ReadLine()));
        }
    }
}