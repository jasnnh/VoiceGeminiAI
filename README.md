# VoiceGeminiAI

[Watch the video!](https://youtu.be/RLOWIt4KLSQ)


C++ Project in Unity Engine using an offline voice recognition library to convert voice talk to text and send that text to Google Gemini AI as a prompt using HTTP Request
The AI.php script is the script communicating to Gemini AI and forwarding the response back to the application.

The GeminiAI.cs C++ script is the script in charge of executing the function inquire which passes the information to the URL http://127.0.0.1/AI.php?data="THIS IS OUR PROMPT TEXT"

I'm not able to show the C++ script for the Audio input capture since it's a paid library and I don't own the asset, but the name is "Undertone"

I have used this same tech in a horror game where you can talk to the AI ghost

Watch the video below where i demonstrate my voice input to text and forward the data to Gemini!
