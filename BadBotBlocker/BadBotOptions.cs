using System.Net;

namespace BadBotBlocker;

/// <summary>
/// Represents the options for the BadBotBlocker.
/// </summary>
public sealed class BadBotOptions
{
    /// <summary>
    /// Gets the list of bad bot patterns.
    /// </summary>
    public List<string> BadBotPatterns { get; } = new List<string>();

    /// <summary>
    /// Gets the list of blocked IP ranges.
    /// </summary>
    public List<(IPAddress NetworkAddress, int PrefixLength)> BlockedIPRanges { get; } =
        new List<(IPAddress, int)>();

    /// <summary>
    /// Initializes a new instance of the <see cref="BadBotOptions"/> class.
    /// </summary>
    public BadBotOptions()
    {
        // Load default patterns and IP ranges
        this.LoadDefaultBadBotPatterns();
        this.LoadDefaultBlockedIPRanges();
    }

    /// <summary>
    /// Adds a bad bot pattern to the list.
    /// </summary>
    /// <param name="pattern">The bad bot pattern to add.</param>
    /// <returns>The <see cref="BadBotOptions"/> instance.</returns>
    public BadBotOptions AddBadBotPattern(string pattern)
    {
        this.BadBotPatterns.Add(pattern);
        return this;
    }

    /// <summary>
    /// Adds a blocked IP range to the list.
    /// </summary>
    /// <param name="cidr">The CIDR notation representing the blocked IP range.</param>
    /// <returns>The <see cref="BadBotOptions"/> instance.</returns>
    /// <exception cref="FormatException">Thrown when the CIDR notation is invalid.</exception>
    public BadBotOptions AddBlockedIPRange(string cidr)
    {
        var parts = cidr.Split('/');

        if (parts.Length != 2)
        {
            throw new FormatException("Invalid CIDR notation");
        }

        var networkAddress = IPAddress.Parse(parts[0]);
        var prefixLength = int.Parse(parts[1]);

        this.BlockedIPRanges.Add((networkAddress, prefixLength));

        return this;
    }

    /// <summary>
    /// Clears the list of bad bot patterns.
    /// </summary>
    /// <returns>The <see cref="BadBotOptions"/> instance.</returns>
    public BadBotOptions ClearBadBotPatterns()
    {
        this.BadBotPatterns.Clear();
        return this;
    }

    /// <summary>
    /// Clears the list of blocked IP ranges.
    /// </summary>
    /// <returns>The <see cref="BadBotOptions"/> instance.</returns>
    public BadBotOptions ClearBlockedIPRanges()
    {
        this.BlockedIPRanges.Clear();
        return this;
    }

    /// <summary>
    /// Loads the default bad bot patterns.
    /// </summary>
    private void LoadDefaultBadBotPatterns()
    {
        var patterns = new[]
        {
            "^Aboundex",
            "^80legs",
            // ... (remaining patterns omitted for brevity)
            "Baiduspider",
            "Yandex",
        };

        this.BadBotPatterns.AddRange(patterns);
    }

    /// <summary>
    /// Loads the default blocked IP ranges.
    /// </summary>
    private void LoadDefaultBlockedIPRanges()
    {
        var ipRanges = new[]
        {
            // Cyveillance
            "38.100.19.8/29",
            "38.100.21.0/24",
            // ... (remaining IP ranges omitted for brevity)
            "65.222.185.72/29",
        };

        foreach (var cidr in ipRanges)
        {
            this.AddBlockedIPRange(cidr);
        }
    }
}
