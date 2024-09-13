using System.Text.RegularExpressions;

namespace BadBotBlocker;

/// <summary>
/// Represents a regular expression pattern matcher.
/// </summary>
public class RegexPatternMatcher : IPatternMatcher
{
    private readonly Regex regex;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegexPatternMatcher"/> class with the specified pattern.
    /// </summary>
    /// <param name="pattern">The regular expression pattern.</param>
    public RegexPatternMatcher(string pattern)
    {
        this.regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }

    /// <summary>
    /// Determines whether the specified input matches the regular expression pattern.
    /// </summary>
    /// <param name="input">The input string to match.</param>
    /// <returns><c>true</c> if the input matches the pattern; otherwise, <c>false</c>.</returns>
    public bool IsMatch(string input)
    {
        return this.regex.IsMatch(input);
    }
}
