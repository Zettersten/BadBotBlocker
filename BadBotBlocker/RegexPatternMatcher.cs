using System.Text.RegularExpressions;

namespace BadBotBlocker;

public class RegexPatternMatcher(string pattern) : IPatternMatcher
{
    private readonly Regex regex = new(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public bool IsMatch(string input)
    {
        return this.regex.IsMatch(input);
    }
}
