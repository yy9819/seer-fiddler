using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace seer_fiddler.core
{
    public class Global
    {
        public static Dictionary<int, int> petSkinsPlanDic = new Dictionary<int, int>();
        public static Dictionary<string, bool> transparentDic = new Dictionary<string, bool>()
        {
            { "transparentPet", true },
            { "transparentSkill",true },
            { "batteryDormantSwitch",true },
        };
    }
    public class IniFile
    {
        private string filePath;

        public IniFile(string path)
        {
            filePath = path;
        }

        public string Read(string section, string key)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                string currentSection = null;
                foreach (string line in lines)
                {
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        currentSection = line.Substring(1, line.Length - 2);
                    }
                    else if (currentSection == section)
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2 && parts[0].Trim() == key)
                        {
                            return parts[1].Trim();
                        }
                    }
                }
            }
            return null;
        }

        public void Write(string section, string key, string value)
        {
            if (File.Exists(filePath))
            {
                List<string> newLines = new List<string>();
                string currentSection = null;
                bool found = false;

                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        if (currentSection == section && !found)
                        {
                            newLines.Add($"{key}={value}");
                            found = true;
                        }
                        newLines.Add(line);
                        currentSection = line.Substring(1, line.Length - 2);
                    }
                    else if (currentSection == section && line.TrimStart().StartsWith(key + "="))
                    {
                        newLines.Add($"{key}={value}");
                        found = true;
                    }
                    else
                    {
                        newLines.Add(line);
                    }
                }

                if (!found)
                {
                    newLines.Add($"[{section}]");
                    newLines.Add($"{key}={value}");
                }

                File.WriteAllLines(filePath, newLines);
            }
            else
            {
                // Handle the case where the INI file does not exist.
            }
        }
    }
}
