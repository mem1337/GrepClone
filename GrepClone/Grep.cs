using System.Runtime.InteropServices.JavaScript;

namespace GrepClone;

public class ScanText
{
    public string Text {get; set;}
    public string? Result { get; set; }
    public ScanText(string text)
    {
        Text = text;
    }
    public string Search(string prompt)
    {
        var lines = Text.Split(new [] { '\r', '\n' });
        for (int i = 0; i < lines.Length; i++)
        {
            var words = lines[i].Split(new [] {' '});
            foreach (var word in words)
            {
                if (word.Contains(prompt))
                {
                    Result+=$"{lines[i]} \n";
                }
            }
        }
        return Result;
    }
}