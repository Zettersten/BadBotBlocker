namespace BadBotBlocker;

/// <summary>
/// Represents a pattern matcher that checks if a string starts with a specific pattern.
/// </summary>
public class StartsWithPatternMatcher : IPatternMatcher
{
    private readonly string pattern;

    /// <summary>
    /// Initializes a new instance of the <see cref="StartsWithPatternMatcher"/> class with the specified pattern.
    /// </summary>
    /// <param name="pattern">The pattern to match.</param>
    public StartsWithPatternMatcher(string pattern)
    {
        this.pattern = pattern;
    }

    /// <summary>
    /// Determines whether the specified input string starts with the pattern.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    /// <returns><c>true</c> if the input string starts with the pattern; otherwise, <c>false</c>.</returns>
    public bool IsMatch(string input)
    {
        return input.StartsWith(this.pattern, StringComparison.OrdinalIgnoreCase);
    }
}
