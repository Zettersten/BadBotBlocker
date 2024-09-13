namespace BadBotBlocker;

/// <summary>
/// Represents a pattern matcher.
/// </summary>
public interface IPatternMatcher
{
    /// <summary>
    /// Determines whether the specified input matches the pattern.
    /// </summary>
    /// <param name="input">The input string to match.</param>
    /// <returns><c>true</c> if the input matches the pattern; otherwise, <c>false</c>.</returns>
    bool IsMatch(string input);
}
