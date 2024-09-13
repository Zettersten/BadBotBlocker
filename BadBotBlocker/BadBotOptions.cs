using System.Net;

namespace BadBotBlocker;

public sealed class BadBotOptions
{
    public List<string> BadBotPatterns { get; } = [];

    public List<(IPAddress NetworkAddress, int PrefixLength)> BlockedIPRanges { get; } = [];

    public BadBotOptions()
    {
        // Load default patterns and IP ranges
        this.LoadDefaultBadBotPatterns();
        this.LoadDefaultBlockedIPRanges();
    }

    public BadBotOptions AddBadBotPattern(string pattern)
    {
        this.BadBotPatterns.Add(pattern);
        return this;
    }

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

    public BadBotOptions ClearBadBotPatterns()
    {
        this.BadBotPatterns.Clear();
        return this;
    }

    public BadBotOptions ClearBlockedIPRanges()
    {
        this.BlockedIPRanges.Clear();
        return this;
    }

    private void LoadDefaultBadBotPatterns()
    {
        var patterns = new[]
        {
        "^Aboundex",
        "^80legs",
        "^360Spider",
        "^Java",
        "^Cogentbot",
        "^Alexibot",
        "^asterias",
        "^attach",
        "^BackDoorBot",
        "^BackWeb",
        "Bandit",
        "^BatchFTP",
        "^Bigfoot",
        "^Black.Hole",
        "^BlackWidow",
        "^BlowFish",
        "^BotALot",
        "Buddy",
        "^BuiltBotTough",
        "^Bullseye",
        "^BunnySlippers",
        "^Cegbfeieh",
        "^CheeseBot",
        "^CherryPicker",
        "^ChinaClaw",
        "Collector",
        "Copier",
        "^CopyRightCheck",
        "^cosmos",
        "^Crescent",
        "^Custo",
        "^AIBOT",
        "^DISCo",
        "^DIIbot",
        "^DittoSpyder",
        "^Download Demon",
        "^Download Devil",
        "^Download Wonder",
        "^dragonfly",
        "^Drip",
        "^eCatch",
        "^EasyDL",
        "^ebingbong",
        "^EirGrabber",
        "^EmailCollector",
        "^EmailSiphon",
        "^EmailWolf",
        "^EroCrawler",
        "^Exabot",
        "^Express WebPictures",
        "Extractor",
        "^EyeNetIE",
        "^Foobot",
        "^flunky",
        "^FrontPage",
        "^Go-Ahead-Got-It",
        "^gotit",
        "^GrabNet",
        "^Grafula",
        "^Harvest",
        "^hloader",
        "^HMView",
        "^HTTrack",
        "^humanlinks",
        "^IlseBot",
        "^Image Stripper",
        "^Image Sucker",
        "Indy Library",
        "^InfoNaviRobot",
        "^InfoTekies",
        "^Intelliseek",
        "^InterGET",
        "^Internet Ninja",
        "^Iria",
        "^Jakarta",
        "^JennyBot",
        "^JetCar",
        "^JOC",
        "^JustView",
        "^Jyxobot",
        "^Kenjin.Spider",
        "^Keyword.Density",
        "^larbin",
        "^LexiBot",
        "^lftp",
        "^libWeb/clsHTTP",
        "^likse",
        "^LinkextractorPro",
        "^LinkScan/8.1a.Unix",
        "^LNSpiderguy",
        "^LinkWalker",
        "^lwp-trivial",
        "^LWP::Simple",
        "^Magnet",
        "^Mag-Net",
        "^MarkWatch",
        "^Mass Downloader",
        "^Mata.Hari",
        "^Memo",
        "^Microsoft.URL",
        "^Microsoft URL Control",
        "^MIDown tool",
        "^MIIxpc",
        "^Mirror",
        "^Missigua Locator",
        "^Mister PiX",
        "^moget",
        "^Mozilla/3.Mozilla/2.01",
        "^Mozilla.*NEWT",
        "^NAMEPROTECT",
        "^Navroad",
        "^NearSite",
        "^NetAnts",
        "^Netcraft",
        "^NetMechanic",
        "^NetSpider",
        "^Net Vampire",
        "^NetZIP",
        "^NextGenSearchBot",
        "^NG",
        "^NICErsPRO",
        "^niki-bot",
        "^NimbleCrawler",
        "^Ninja",
        "^NPbot",
        "^Octopus",
        "^Offline Explorer",
        "^Offline Navigator",
        "^Openfind",
        "^OutfoxBot",
        "^PageGrabber",
        "^Papa Foto",
        "^pavuk",
        "^pcBrowser",
        "^PHP version tracker",
        "^Pockey",
        "^ProPowerBot/2.14",
        "^ProWebWalker",
        "^psbot",
        "^Pump",
        "^QueryN.Metasearch",
        "^RealDownload",
        "Reaper",
        "Recorder",
        "^ReGet",
        "^RepoMonkey",
        "^RMA",
        "Siphon",
        "^SiteSnagger",
        "^SlySearch",
        "^SmartDownload",
        "^Snake",
        "^Snapbot",
        "^Snoopy",
        "^sogou",
        "^SpaceBison",
        "^SpankBot",
        "^spanner",
        "^Sqworm",
        "Stripper",
        "Sucker",
        "^SuperBot",
        "^SuperHTTP",
        "^Surfbot",
        "^suzuran",
        "^Szukacz/1.4",
        "^tAkeOut",
        "^Teleport",
        "^Telesoft",
        "^TurnitinBot/1.5",
        "^The.Intraformant",
        "^TheNomad",
        "^TightTwatBot",
        "^Titan",
        "^True_Robot",
        "^turingos",
        "^TurnitinBot",
        "^URLy.Warning",
        "^Vacuum",
        "^VCI",
        "^VoidEYE",
        "^Web Image Collector",
        "^Web Sucker",
        "^WebAuto",
        "^WebBandit",
        "^Webclipping.com",
        "^WebCopier",
        "^WebEMailExtrac.*",
        "^WebEnhancer",
        "^WebFetch",
        "^WebGo IS",
        "^Web.Image.Collector",
        "^WebLeacher",
        "^WebmasterWorldForumBot",
        "^WebReaper",
        "^WebSauger",
        "^Website eXtractor",
        "^Website Quester",
        "^Webster",
        "^WebStripper",
        "^WebWhacker",
        "^WebZIP",
        "Whacker",
        "^Widow",
        "^WISENutbot",
        "^WWWOFFLE",
        "^WWW-Collector-E",
        "^Xaldon",
        "^Xenu",
        "^Zeus",
        "ZmEu",
        "^Zyborg",
        // Vulnerability Scanners
        "Acunetix",
        "FHscan",
        // Aggressive Search Engines
        "Baiduspider",
        "Yandex",
    };

        this.BadBotPatterns.AddRange(patterns);
    }

    private void LoadDefaultBlockedIPRanges()
    {
        var ipRanges = new[]
        {
        // Cyveillance
        "38.100.19.8/29",
        "38.100.21.0/24",
        "38.100.41.64/26",
        "38.105.71.0/25",
        "38.105.83.0/27",
        "38.112.21.140/30",
        "38.118.42.32/29",
        "65.213.208.128/27",
        "65.222.176.96/27",
        "65.222.185.72/29",
    };

        foreach (var cidr in ipRanges)
        {
            this.AddBlockedIPRange(cidr);
        }
    }
}
