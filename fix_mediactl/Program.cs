// See https://aka.ms/new-console-template for more information
string patchName = "media control to playerctl";
Console.WriteLine("Patching " + patchName + "...");
string contentToFill = "playerctl {next,previous,play-pause,stop}";
string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string checkStr = "XF86Audio{Next,Prev,Play,Stop}";
string configFile = homeDir + @"/.config/bspwm/sxhkdrc";
string configSpacer = "        ";
string[] fileContent = File.ReadAllLines(configFile);
for (int i = 0; i < fileContent.Length; i++)
{
    if (fileContent[i].Contains(checkStr))
    {
        Console.WriteLine("Overwriting " + fileContent[i + 1]);
        fileContent[i + 1] = configSpacer + contentToFill;
    }
}

File.WriteAllLines(configFile, fileContent);
Console.WriteLine("Patching " + patchName + " done");


