#include <iostream>
#include <winhttp.h>

struct Game
{
	std::string name;
	std::string fullName;
	std::string downloadURL;
	std::string versionURL;
};

int main()
{
	Game Launcher;

	Launcher.fullName = "Launcher";
	Launcher.name = "Launcher";
	Launcher.downloadURL = "https://github.com/GCJOJO/FrenchPixelLauncher/releases/latest/download/FrenchPixelLauncher.exe";
	Launcher.versionURL = "https://github.com/GCJOJO/FrenchPixelLauncher/releases/latest/download/FPL_WebVersion";

	
}