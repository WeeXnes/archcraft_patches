Console.WriteLine("Patching Intel Xe Renderer");
string[] fileContent = new []{
    "Section \"Device\"",
    "    Identifier      \"Intel Graphics\"",
    "    Driver          \"modesetting\"",
    "    Option          \"AccelMethod\"   \"glamor\"",
    "    Option          \"DRI\"           \"3\"",
    "EndSection"
};
File.WriteAllLines("/etc/X11/xorg.conf.d/20-intel.conf", fileContent);
Console.WriteLine("Patching done");