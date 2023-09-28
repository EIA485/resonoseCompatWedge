using System;
using System.Collections.Generic;
using Mono.Cecil;
using System.Linq;
using System.Runtime.CompilerServices;
namespace codeGenerator
{
    internal class Program
    {
        const string neosBinPath = @"C:\Program Files (x86)\Steam\steamapps\common\NeosVR\Neos_Data\Managed\";
        const string resoBinPath = @"C:\Program Files (x86)\Steam\steamapps\common\Resonite\Resonite_Data\Managed\publicized_assemblies\";
        static readonly (string oldname, string newname)[] namePairs = { ("BaseX", "Elements.Core"), ("CodeX", "Elements.Assets"), ("CloudX.Shared", "SkyFrost.Base") };
        static readonly Dictionary<string, string> renamelut = new Dictionary<string, string> { { "CloudX", "SkyFrost" }, { "NeosBuildConfiguration", "AppBuildConfiguration" }, { "INeos", "I" }, { "NeosHub", "AppHub" }, { "BuildVariantBase", "BuildVariantDescriptor" }, { "NeosBuildVariant", "AppBuildVariantDescriptor" }, { "NeosConfig", "AppConfig" }, { "OnlineUserStats", "OnlineStats" }, { "PatreonSnapshot", "LegacyPatreonSnapshot" }, { "UserPatreonData", "LegacyUserPatreonData" }, { "Neos", "" }, { "Soli", "" }, { "Friend", "Contact" } };
        static void Main(string[] args)
        {
            foreach ((string oldName, string newName) in namePairs)
            {
                Console.WriteLine(oldName);
                var oldNames = OpenAsm(neosBinPath, oldName).GetTypes().Select(t => t.Name);
                Dictionary<string, TypeDefinition> lut = new();
                foreach (var t in OpenAsm(resoBinPath, newName).GetTypes())
                {
                    if (t.IsNested) continue;
                    lut[t.Name] = t;
                }
                HashSet<string> log = new();
                foreach (var old in oldNames)
                {
                    if (lut.Keys.Contains(old)) Console.WriteLine($"[assembly: TypeForwardedTo(typeof({TypeFullName(lut[old])}))]");
                }
            }
            Console.Read();
        }
        static ModuleDefinition OpenAsm(string path, string filename) => ModuleDefinition.ReadModule(path + filename + ".dll");
        static string TypeFullName(TypeReference self)
        {
            var str = string.IsNullOrEmpty(self.Namespace)
                ? self.Name
                : self.Namespace + '.' + self.Name;
            if (self.HasGenericParameters)
            {
                return str.Substring(0, str.Length - (1 + self.GenericParameters.Count.ToString().Length)) + '<' + new string(',', self.GenericParameters.Count - 1) + '>';
            }
            return str;
        }
        static string nameConverter(string oldName)
        {
            foreach (var change in renamelut)
            {
                oldName = oldName.Replace(change.Key, change.Value);
            }
            return oldName;
        }
    }
}