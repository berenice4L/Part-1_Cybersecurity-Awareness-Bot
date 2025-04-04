# Part-1_Cybersecurity-Awareness-Bot
# 🔒 Cybersecurity Awareness Bot

![ASCII Art Logo](Assets/ascii_art.txt)

A console-based chatbot that educates users about cybersecurity best practices, featuring voice greetings and interactive Q&A.

## Features

- **Voice Greeting**: Plays welcome message on startup
- **Interactive Chat**: Responds to cybersecurity questions
- **ASCII Art**: Displays cool cybersecurity-themed artwork
- **User Personalization**: Addresses users by name
- **Input Validation**: Handles unexpected inputs gracefully

 🛠️ Technologies Used

- C# (.NET 6)
- `System.Media` for audio playback
- GitHub Actions for CI
- ASCII art for console visuals

## 📦 Installation

1. Clone the repository:
   git clone https://github.com/HlulaniMfomande/cybersecurity-bot.git

2. Build the project:
dotnet build

🎮USAGE

3. Run the application:
dotnet run

Example of interaction:

What's your name? Hlulani
Hello Hlulani! I'm your Cybersecurity Awareness Assistant.
Type 'help' to see what I can do.

You: passwords
Bot: Strong passwords should be at least 12 characters...

4. 📁 Project Structure
├── Assets/               # Resource files
│   ├── greeting.wav      # Voice greeting
│   └── ascii_art.txt     # ASCII logo
├── Program.cs            # Main application code
├── README.md             # This file
└── .github/workflows/    # CI configuration
    └── dotnet.yml        # GitHub Actions workflow


5. 🤖 Command Reference
Command	Response
help	Shows available commands
passwords	Password security tips
phishing	How to spot phishing attempts
browsing	Safe web browsing practices
exit	Ends the conversation

6. 🛅 GitHub CI Pipeline
The project includes GitHub Actions configured to:

Run on every push
Build the project
Run tests (if any)
Verify code integrity

7. 📝 License
This project is licensed under the MIT License - see the LICENSE file for details.
