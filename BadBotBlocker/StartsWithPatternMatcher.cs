namespace BadBotBlocker;

public class StartsWithPatternMatcher(string pattern) : IPatternMatcher
{
    private readonly string pattern = pattern;

    public bool IsMatch(string input)
    {
        return input.StartsWith(this.pattern, StringComparison.OrdinalIgnoreCase);
    }
}
