# 🔐 CyberSecurity Chatbot 3.0

**CyberSecurity Chatbot 3.0** is a fun, interactive console-based chatbot that provides cybersecurity awareness tips using a rich user experience including ASCII art, sound greetings, colorful console UI, and keyword-based intelligent responses.

---

## 🧠 Features

- 🎨 ASCII Art Intro Screen with animated messages
- 🎧 Optional voice greeting (`greeting.wav`)
- 💬 Responds to cybersecurity-related queries (e.g., passwords, phishing, VPNs)
- 🧠 Keyword and direct-matching response logic
- 🧾 Educational and informative replies
- 🌐 Easter egg: type "matrix" for a hidden surprise
- 🚫 Recognizes negative sentiment and offers helpful reassurance

---

## 🚀 Getting Started

### Prerequisites

- .NET SDK (Core or Framework) installed on your machine
- Windows OS (uses `System.Media.SoundPlayer`)
- Console with Unicode support

### File Structure

```
CyberSecurityChatbot/
│
├── Assets/
│   └── greeting.wav            # Optional: greeting sound played on startup
│
├── Program.cs                  # Contains the chatbot source code
└── README.md                   # You're here!
```

### Build and Run

1. Clone or download this repository.
2. Open a terminal in the project directory.
3. Build and run:

```bash
dotnet run
```

---

## 💬 Commands You Can Try

| Topic          | Example User Input                 |
|----------------|------------------------------------|
| Passwords      | "tell me about password safety"    |
| Phishing       | "what is phishing?"                |
| Malware        | "info on malware"                  |
| VPN            | "how does a VPN work?"             |
| 2FA            | "what is 2fa?"                     |
| Privacy        | "privacy tips"                     |
| Help           | "help" or "what can I ask?"        |
| Exit           | "exit"                             |
| Easter Egg     | "matrix"                           |

---

## 🛠️ Customization

You can expand or personalize the bot by modifying:

- `responsePool`
- `directResponses`
- `Assets/greeting.wav`
- `DisplayAsciiArt()`

---

## 🤖 Technical Highlights

- **Color-coded console messages** for improved UX
- **Typewriter-style output** using delays for responses
- **Sentiment detection** on input strings
- **Randomized tips** from pools of cybersecurity advice
- **Interactive and humorous tone** for educational appeal

---

## 🧩 Easter Egg

Type **"matrix"** at any time to unlock a surprise terminal animation and message. 🟩

---

## 📄 License

This project is licensed under the MIT License — feel free to use and modify it for personal or educational use.

---

## 🙋‍♂️ Author

Developed with ❤️ to promote **cybersecurity awareness** in a fun and engaging way. Stay safe online!
