using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace BadBotBlocker;

/// <summary>
/// Represents a regular expression pattern matcher.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RegexPatternMatcher"/> class with the specified pattern.
/// </remarks>
/// <param name="pattern">The regular expression pattern.</param>
public class RegexPatternMatcher([StringSyntax(StringSyntaxAttribute.Regex)] string pattern)
    : IPatternMatcher
{
    private readonly Regex regex = new(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

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
