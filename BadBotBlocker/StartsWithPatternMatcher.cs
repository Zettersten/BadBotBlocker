namespace BadBotBlocker;

/// <summary>
/// Represents a pattern matcher that checks if a string starts with a specific pattern.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="StartsWithPatternMatcher"/> class with the specified pattern.
/// </remarks>
/// <param name="pattern">The pattern to match.</param>
public class StartsWithPatternMatcher(string pattern) : IPatternMatcher
{
    /// <summary>
    /// Determines whether the specified input string starts with the pattern.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    /// <returns><c>true</c> if the input string starts with the pattern; otherwise, <c>false</c>.</returns>
    public bool IsMatch(string input)
    {
        return input.StartsWith(pattern, StringComparison.OrdinalIgnoreCase);
    }
}
