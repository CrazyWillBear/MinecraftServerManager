# MinecraftServerManager
A console application used to create and manage Minecraft servers.

## News:
- I think I need to add an uninstall command into the software itself, although that feels super weird... I'll think about other ways to implement the uninstaller
- Java automatically asks for permission to open ports, no reason to do it manually
- The software will be installed for the whole computer, not just one user
- I really want to implement NGROK into this somehow
- I wrapped the installer into a .msi, which when you run it looks kind of weird but functions perfectly and is better than having a ton of dependencies when you run the installer

## Summary
This software is coded in C# for Windows 10 64-bit. As of now it can create, delete, start, and list servers that you create. It uses several services (all in credits) to do this, and installs server jars from Paper, Spigot, Bukkit, and Vanilla (Mojang). The software is still in prealpha, meaning that there will be many bugs and missing features. Much work will be done and much progress made. Suggestions and edits to the code are always welcome.

## Goals:
- Integrate NGROK for on the go custom IPs
- Create a directory structure that both looks cool and operates easily

## Requirements:
- Windows 10 64-bit
- An internet connection
- Storage space available
- Java installed (installer will check for this)
- Command prompt

*P.S. It's not mine, and if you can ignore the cringiness it gets the job done

## Credits
Many credits are due here. For starters:
- PaperMC (https://papermc.io/)
- SpigotMC (https://www.spigotmc.org/)
- Bukkit(https://bukkit.org/)
- Minecraft/Mojang (https://www.minecraft.net/en-us/)
- Newtonsoft (https://www.newtonsoft.com/json)
- ServerJars (https://serverjars.com/)

Paper, Spigot, Bukkit, and Minecraft/Mojang provide server jars. Paper provides their own API to do everything with. For Spigot Bukkit and Minecraft/Mojang, I used ServerJars which has their own API and download mirrors for server jars. I also got help from members of StackOverflow (pertaining specifically to the ConsoleSpinner, located in `MinecraftServerManager/Utils/ConsoleSpinner.cs`).

## License
I have chosen the MIT License so that my software can be modified and improved freely without restriction. Enjoy!
