using GrepClone;

class Program
{
    static void Main(string[] args)
    {
        while(true)
        {
            string text = File.ReadAllText("TextFile");
            ScanText scanText = new ScanText(text);
            Console.Write("What are you searching for: ");
            string prompt = Console.ReadLine();
            Console.WriteLine(scanText.Search(prompt));
        }
    }
}