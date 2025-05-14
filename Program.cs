using System;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class CyberSecurityChatbot
{
    private static string userName;
    private static ConsoleColor botColor = ConsoleColor.Cyan;
    private static ConsoleColor warningColor = ConsoleColor.Yellow;
    private static ConsoleColor errorColor = ConsoleColor.Red;
    private static ConsoleColor successColor = ConsoleColor.Green;
    private static ConsoleColor inputColor = ConsoleColor.White;
    private static ConsoleColor highlightColor = ConsoleColor.Magenta;

    private static Dictionary<string, List<string>> responsePool = new Dictionary<string, List<string>>()
    {
        {"password", new List<string>{
            "🔒 Make sure to use complex, unique passwords for each account. Avoid using personal information!",
            "💡 Tip: A strong password should be at least 12 characters long with a mix of letters, numbers, and symbols!",
            "🔑 Did you know? Password managers like Bitwarden or 1Password can generate and store secure passwords for you!"
        }},
        {"phishing", new List<string>{
            "🎣 Phishing emails often pretend to be from trusted sources. Always verify the sender's address!",
            "⚠️ Never click on suspicious links or download attachments from unknown senders!",
            "🔍 Look for spelling mistakes and urgent language—common signs of phishing scams!"
        }},
        {"malware", new List<string>{
            "🦠 Malware includes viruses, worms, and ransomware. Keep your antivirus updated!",
            "🚫 Never download software from untrusted sources—always verify checksums!",
            "💻 Use tools like Malwarebytes for extra protection against spyware and adware!"
        }},
        {"privacy", new List<string>{
            "👁️ Regularly review privacy settings on social media platforms!",
            "🌐 Use privacy-focused browsers (like Brave or Firefox with uBlock Origin)!",
            "📵 Be cautious about sharing personal info online—once it's out, it's hard to take back!"
        }},
        {"vpn", new List<string>{
            "🛡️ A VPN encrypts your internet traffic, hiding it from snoopers!",
            "🌍 Always use a VPN on public Wi-Fi to prevent man-in-the-middle attacks!",
            "🤫 Choose a no-logs VPN like ProtonVPN or Mullvad for maximum privacy!"
        }},
        {"2fa", new List<string>{
            "🔐 Two-Factor Authentication (2FA) adds an extra layer of security!",
            "📱 Use authenticator apps (Google Authenticator, Authy) instead of SMS for 2FA!",
            "⚠️ Never share 2FA codes—legitimate services will NEVER ask for them!"
        }}
    };

    private static Dictionary<string, string> directResponses = new Dictionary<string, string>()
    {
        {"hello", "👋 Hi there! Ready to boost your cybersecurity knowledge?"},
        {"how are you", "I'm always scanning for threats! How about you?"},
        {"what's your purpose", "I provide cybersecurity tips and answer security-related questions! 🔍"},
        {"what can i ask", "Try: 'password safety', 'phishing', 'malware', 'VPN', or '2FA'!"},
        {"what is cybersecurity", "Cybersecurity protects systems/networks from digital attacks! 🛡️"},
        {"what is a cyber attack", "A malicious act targeting systems to steal, alter, or destroy data! 💻🔥"},
        {"exit", "🚪 Goodbye! Stay safe out there in the digital wilderness!"},
        {"help", "📜 Available commands:\n• password tips\n• phishing info\n• malware\n• VPN\n• 2FA\n• exit"}
    };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Title = "🔐 CYBERSECURITY BOT 3.0 🔐";
        Console.Clear();
        PlayVoiceGreeting();
        DisplayAsciiArt();
        GreetUser();
        StartChat();
    }

    static void PlayVoiceGreeting()
    {
        string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav");
        try
        {
            if (File.Exists(audioPath))
            {
                using (SoundPlayer player = new SoundPlayer(audioPath))
                {
                    player.Play();
                }
            }
            else
            {
                PrintColored("[Audio] Greeting file not found.", warningColor);
            }
        }
        catch (Exception ex)
        {
            PrintColored($"[Audio Error] {ex.Message}", errorColor);
        }
    }

    static void DisplayAsciiArt()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;

        string[] asciiArt = new string[]
        {
        @"      █████████                    ████                █████  ███                     ",
        @"     ███░░░░░███                  ░░███               ░░███  ░░░                      ",
        @"    ███     ░░░   ██████   ██████  ░███   ██████    ███████  ████   ██████  ████████  ",
        @"   ░███          ███░░███ ███░░███ ░███  ░░░░░███  ███░░███ ░░███  ███░░███░░███░░███ ",
        @"   ░███         ░███ ░███░███ ░███ ░███   ███████ ░███ ░███  ░███ ░███ ░███ ░███ ░███ ",
        @"   ░░███     ███░███ ░███░███ ░███ ░███  ███░░███ ░███ ░███  ░███ ░███ ░███ ░███ ░███ ",
        @"    ░░█████████ ░░██████ ░░██████  █████░░████████░░████████ █████░░██████  ████ █████",
        @"     ░░░░░░░░░   ░░░░░░   ░░░░░░  ░░░░░  ░░░░░░░░  ░░░░░░░░ ░░░░░  ░░░░░░  ░░░░ ░░░░░ "
        };

        foreach (var line in asciiArt)
        {
            Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
            Console.WriteLine(line);
        }

        Console.ForegroundColor = ConsoleColor.Red;
        string borderTop = "╔══════════════════════════════════════════════════════════════╗";
        Console.SetCursorPosition((Console.WindowWidth - borderTop.Length) / 2, Console.CursorTop);
        Console.WriteLine(borderTop);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition((Console.WindowWidth - 66) / 2, Console.CursorTop);
        Console.Write(" ║   ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("        C Y B E R S E C U R I T Y");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("   B O T");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("   3.0    ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("        ║");

        Console.ForegroundColor = ConsoleColor.Red;
        string borderBottom = "╚══════════════════════════════════════════════════════════════╝";
        Console.SetCursorPosition((Console.WindowWidth - borderBottom.Length) / 2, Console.CursorTop);
        Console.WriteLine(borderBottom);


        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.SetCursorPosition((Console.WindowWidth - 54) / 2, Console.CursorTop);
        Console.WriteLine("╔══════════════════════════════════════════════════╗");
        Console.SetCursorPosition((Console.WindowWidth - 54) / 2, Console.CursorTop);
        Console.Write("║   ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("   ⚡ Secure • Protect • Defend • Empower ⚡  ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("   ║");
        Console.SetCursorPosition((Console.WindowWidth - 54) / 2, Console.CursorTop);
        Console.WriteLine("╚══════════════════════════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.Magenta;
        string[] banner = {
            "★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★",
            "  W E L C O M E   T O   T H E   ",
            "  C Y B E R S E C U R I T Y   A W A R E N E S S   B O T !",
            "★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★"
        };

        foreach (var line in banner)
        {
            Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
            Console.WriteLine(line);
        }

        Console.ResetColor();
    }

    static void GreetUser()
    {
        PrintWithBorder("USER REGISTRATION", ConsoleColor.DarkCyan);
        PrintColored("\nPlease enter your name to begin: ", ConsoleColor.White);
        Console.ForegroundColor = inputColor;
        userName = Console.ReadLine();

        TypeResponse($"\n🔓 Hello, {userName}! ", botColor, 50);
        TypeResponse("How can I help you stay safe online today?\n", botColor, 30);
    }

    static void StartChat()
    {
        while (true)
        {
            PrintColored("\n╭────────────────────────────────────────╮", ConsoleColor.DarkGray);
            PrintColored("│  Ask me about cybersecurity (or 'exit') │", ConsoleColor.DarkGray);
            PrintColored("╰────────────────────────────────────────╯", ConsoleColor.DarkGray);
            Console.Write("\n> ");
            Console.ForegroundColor = inputColor;
            string userInput = Console.ReadLine()?.ToLower();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                PrintColored("Please enter a valid question.", warningColor);
                continue;
            }

            if (userInput.Contains("exit"))
            {
                PrintWithBorder($"🚪 Goodbye, {userName}! Stay secure online!", successColor);
                Thread.Sleep(2000);
                return;
            }

            if (userInput.Contains("matrix"))
            {
                RunMatrixEasterEgg();
                continue;
            }

            if (HasNegativeSentiment(userInput))
            {
                PrintColored($"\nI sense frustration, {userName}. Let me clarify...\n", warningColor);
            }

            string response = GenerateResponse(userInput);
            TypeResponse("\nBot: ", botColor, 20);
            TypeResponse(response + "\n", ConsoleColor.Gray, 10);
        }
    }

    static string GenerateResponse(string input)
    {
        foreach (var pair in directResponses)
        {
            if (input.Contains(pair.Key))
                return pair.Value;
        }

        foreach (var keyword in responsePool.Keys)
        {
            if (input.Contains(keyword))
            {
                var responses = responsePool[keyword];
                return responses[new Random().Next(responses.Count)];
            }
        }

        if (input.Contains("more") || input.Contains("detail"))
            return "🔍 Here's additional info:\n" +
                   "└─ " + GetAdditionalDetails(input);

        return $"🤔 I'm not sure about that, {userName}. Try asking about:\n" +
               "└─ 'passwords'\n└─ 'phishing'\n└─ 'malware'\n└─ 'VPN'\n└─ '2FA'";
    }

    static string GetAdditionalDetails(string input)
    {
        if (input.Contains("password"))
            return "🔐 Consider using 2FA (Two-Factor Authentication) for extra security!";
        if (input.Contains("phishing"))
            return "📧 Legitimate companies will NEVER ask for passwords via email!";
        if (input.Contains("privacy"))
            return "🕵️‍♂️ Browser extensions like Privacy Badger can block trackers!";
        if (input.Contains("vpn"))
            return "🌐 VPNs also help bypass geo-restrictions (like streaming content)!";
        if (input.Contains("2fa"))
            return "📲 Backup codes are crucial if you lose your 2FA device!";

        return "⚠️ Cybersecurity is always evolving—stay updated with recent threats!";
    }

    static bool HasNegativeSentiment(string input)
    {
        string[] negativeWords = { "frustrated", "angry", "hate", "confused", "annoyed" };
        return negativeWords.Any(word => input.Contains(word));
    }

    static void RunMatrixEasterEgg()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine("ENTERING THE MATRIX...\n");
        Thread.Sleep(1000);

        Random rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < Console.WindowWidth; j++)
            {
                Console.Write((char)rand.Next(0x30A0, 0x30FF));
            }
            Thread.Sleep(50);
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Wake up, Neo... The cybersecurity bot has you.");
        Thread.Sleep(3000);
        Console.Clear();
        DisplayAsciiArt();
    }

    static void PrintColored(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    static void TypeResponse(string text, ConsoleColor color, int delayMs)
    {
        Console.ForegroundColor = color;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delayMs);
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true);
                Console.Write(text.Substring(Console.CursorLeft));
                break;
            }
        }
        Console.ResetColor();
    }

    static void PrintWithBorder(string text, ConsoleColor color)
    {
        string border = new string('═', text.Length + 4);
        Console.ForegroundColor = color;
        Console.WriteLine($"╔{border}╗");
        Console.WriteLine($"║  {text}  ║");
        Console.WriteLine($"╚{border}╝");
        Console.ResetColor();
    }
}
