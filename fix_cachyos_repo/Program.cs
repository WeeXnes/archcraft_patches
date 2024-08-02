// See https://aka.ms/new-console-template for more information
string patchName = "CachyOS Repo Location in pacman.conf";
Console.WriteLine("Patching " + patchName + "...");
string configFile = Path.GetFullPath("/etc/pacman.conf");
Console.WriteLine(configFile);
string checkStr = "[cachyos";

List<string> linesToAppend = new List<string>();
List<string> clearedFile = new List<string>();
string[] fileContent = File.ReadAllLines(configFile);


for (int i = 0; i < fileContent.Length; i++)
{
    if (fileContent[i].Contains(checkStr))
    {
        //Console.WriteLine("-----------------------------------");
        //Console.WriteLine(fileContent[i]);
        //Console.WriteLine(fileContent[i+1]);
        
        linesToAppend.Add(fileContent[i]);
        linesToAppend.Add(fileContent[i+1]);
        linesToAppend.Add("");
        fileContent[i] = "";
        fileContent[i+1] = "";
        //Console.WriteLine("-----------------------------------");
    }
    clearedFile.Add(fileContent[i]);
}
/*
foreach (var str in clearedFile)
{
    Console.WriteLine(str);
}
*/

Console.WriteLine("Appending the following to pacman.conf: ");
foreach (var str in linesToAppend)
{
    Console.WriteLine(str);
    clearedFile.Add(str);
}

File.WriteAllLines(configFile, clearedFile);
Console.WriteLine("Patching " + patchName + " done");

