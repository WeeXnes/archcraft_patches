// See https://aka.ms/new-console-template for more information
string patchName = "OLED Screen Brightness";
Console.WriteLine("Patching " + patchName + "...");
string contentToFill = "xrandr --output eDP-1 --brightness {$(echo \"$(xrandr --verbose | grep -i brightness | cut -f2 -d ' ') + 0.1\" | bc), $(echo \"$(xrandr --verbose | grep -i brightness | cut -f2 -d ' ') - 0.1\" | bc)}";
string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
string checkStr = "XF86MonBrightness{Up,Down}";
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


