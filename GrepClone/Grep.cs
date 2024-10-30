using System.Text.RegularExpressions;

namespace GrepClone;

public class ScanText
{
    public string Text {get; set;}
    public string? Result;
    public ScanText(string text)
    {
        Text = text;
    }
    public string Search(string prompt)
    {
        var lines = Text.Split(new [] { '\r', '\n' });
        var prompts = prompt.Split(new [] { ' ' });

        Regex flagChecker = new Regex(@"([a-zA-Z]+)(\d+)");
        if (prompt[0].ToString()=="-")
        {
            Match result = flagChecker.Match(prompt);
            string flag = result.Groups[1].Value;
            int lineCount = Convert.ToInt32(result.Groups[2].Value);
            string actualPrompt = String.Join(' ', prompts[1..]);

            switch (flag)
            {
                case("A"):
                for (int i = 0; i < lines.Length; i++)
                {
                    var words = lines[i].Split(new [] {' '});
                    foreach (var word in words)
                    {
                        if (word.Contains(actualPrompt))
                        {
                            for (int j = 0; j <= lineCount; j++)
                            {
                                Result+=$"{lines[i+j]} \n";
                            }
                            return Result;
                        }
                    }
                }
                break;
                case("B"):
                for (int i = 0; i < lines.Length; i++)
                {
                    var words = lines[i].Split(new [] {' '});
                    foreach (var word in words)
                    {
                        if (word.Contains(actualPrompt))
                        {
                            for (int j = lineCount; j >= 0; j--)
                            {
                                Result+=$"{lines[i-j]} \n";
                            }
                            return Result;
                        }
                    }
                }
                break;
                case("C"):
                for (int i = 0; i < lines.Length; i++)
                {
                var words = lines[i].Split(new [] {' '});
                foreach (var word in words)
                    {
                        if (word.Contains(actualPrompt))
                        {
                            for (int j = lineCount; j >= 0; j--)
                            {
                                Result+=$"{lines[i-j]} \n";
                            }
                        }
                    }
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    var words = lines[i].Split(new [] {' '});
                    foreach (var word in words)
                    {
                        if (word.Contains(actualPrompt))
                        {
                            for (int j = 1; j <= lineCount; j++)
                            {
                                Result+=$"{lines[i+j]} \n";
                            }
                            return Result;
                        }
                    }
                }
                break;
            }
        }



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