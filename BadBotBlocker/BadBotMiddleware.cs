using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net;

namespace BadBotBlocker;

public sealed partial class BadBotMiddleware
{
    private readonly RequestDelegate next;
    private readonly List<IPatternMatcher> badBotMatchers;
    private readonly List<(IPAddress NetworkAddress, int PrefixLength)> blockedIPRanges;

    public BadBotMiddleware(RequestDelegate next, IOptions<BadBotOptions> options)
    {
        this.next = next;

        var badBotOptions = options.Value;

        this.badBotMatchers = badBotOptions.BadBotPatterns.Select(pattern =>
            IsStartsWithPattern(pattern)
                ? new StartsWithPatternMatcher(pattern.TrimStart('^')) as IPatternMatcher
                : new RegexPatternMatcher(pattern)
        ).ToList();

        this.blockedIPRanges = badBotOptions.BlockedIPRanges;
    }

    private static bool IsStartsWithPattern(string pattern)
    {
        if (!pattern.StartsWith('^'))
        {
            return false;
        }

        var trimmedPattern = pattern[1..];

        // Check for regex special characters
        return !SpecialCharacterPattern().IsMatch(trimmedPattern);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Check IP address
        var ipAddress = context.Connection.RemoteIpAddress;

        if (ipAddress != null)
        {
            foreach (var (networkAddress, prefixLength) in this.blockedIPRanges)
            {
                if (ipAddress.IsInSubnet(networkAddress, prefixLength))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return;
                }
            }
        }

        // Check User-Agent
        var userAgent = context.Request.Headers["User-Agent"].ToString();

        if (!string.IsNullOrEmpty(userAgent))
        {
            foreach (var matcher in this.badBotMatchers)
            {
                if (matcher.IsMatch(userAgent))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    return;
                }
            }
        }

        await this.next(context);
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"[\.\$\*\+\?\{\}\[\]\|\\]")]
    private static partial System.Text.RegularExpressions.Regex SpecialCharacterPattern();
}
