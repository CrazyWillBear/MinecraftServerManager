# MinecraftServerManager
A console application used to create and manage Minecraft servers running Paper servers

## How to use right now!
Right now, the software is in the prealpha stage of development. As of now, with the release available, you can only create new servers. In order to do so, create a new folder and put the contents of the release .zip file in it. Then, create a folder in that folder called `server`. Finally, open a command prompt in the folder and type `minecraftserversoftware -c <Server name>`. I will shorten the name of the .exe so you don't have to type that whole thing out. You can also type `--create` instead of `-c` if you would like. In theory, if you don't want to type the whole thing out you can manually rename the .exe file. If you keep getting an error on a server, you can just go into your `server` folder and delete the servers you have created. If you would like to keep the server, try running the `start.bat` file manually, and see if the error is related to the server or the application.

## Goals:
- Create an installer (that automatically opens the necessary ports and checks to see if Java is installed)
- Integrate NGROK for on the go custom IPs
- Allow for most versions of Minecraft to be installed
- Create a directory structure that both looks cool and operates easily
