# MinecraftServerManager
A console application used to create and manage Minecraft servers.

## Install:
- Scoop: `scoop bucket add games` -> `scoop install mcservman`
- Run the installer available in releases

## News:
- I really want to implement NGROK into this somehow
- Fixed a bug with the Java installation process. This means that it will install Java, not OpenJDK which is a bit of a bummer but regardless, it's functional

## Summary
This software is coded in C# for Windows. As of now it can create, delete, start, and list servers that you create. It uses several services (all in credits) to do this, and installs server jars from Paper, Spigot, Bukkit, and Vanilla (Mojang). The software is still in prealpha, meaning that there will be many bugs and missing features. Much work will be done and much progress made. Suggestions and edits to the code are always welcome.

## Goals:
- Integrate NGROK for on the go custom IPs

## Requirements:
- Windows (64-bit prefered) (does not work on Mac or Linux, may add support in future but unlikely)
- DOTNET runtime is a MUST
- Java installed (installer will check for this)
- Basic knowledge of Minecraft servers and plugins

## Credits
Many credits are due here. For starters:
- PaperMC (https://papermc.io/)
- SpigotMC (https://www.spigotmc.org/)
- Bukkit (https://bukkit.org/)
- Minecraft/Mojang (https://www.minecraft.net/en-us/)
- Newtonsoft (https://www.newtonsoft.com/json)
- ServerJars (https://serverjars.com/)
- Octokit.net (https://github.com/octokit/octokit.net)

Paper, Spigot, Bukkit, and Minecraft/Mojang provide server jars. Paper provides their own API to do everything with. For Spigot Bukkit and Minecraft/Mojang, I used ServerJars which has their own API and download mirrors for server jars. Octokit makes interacting with GitHub's API super easy and is used in the installer. I also got help from members of StackOverflow (pertaining specifically to the ConsoleSpinner, located in `MinecraftServerManager/Utils/ConsoleSpinner.cs`).

## License
I have chosen the MIT License so that my software can be modified and improved freely without restriction. Enjoy!
