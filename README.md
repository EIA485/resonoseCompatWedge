# resonoseCompatWedge

A Wedge for mods compiled against neos/nml to work with resonite/rml

## Installation
1. Install [ResoniteModLoader](https://github.com/resonite-modding-group/ResoniteModLoader).
1. Place [BaseX.dll](https://github.com/eia485/resonoseCompatWedge/releases/latest/download/BaseX.dll), [CloudX.Shared.dll](https://github.com/eia485/resonoseCompatWedge/releases/latest/download/CloudX.Shared.dll), [CodeX.dll](https://github.com/eia485/resonoseCompatWedge/releases/latest/download/CodeX.dll), [NeosModLoader.dll](https://github.com/eia485/resonoseCompatWedge/releases/latest/download/NeosModLoader.dll) into your `rml_libs` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\Resonite\rml_libs` for a default install. You can create it if it's missing, or if you launch the game once with ResoniteModLoader installed it will create the folder for you.
1. Start the game. Check logs to see if its loaded. some mods may need to be updated to due changes between resonite and neos

## contributing
feel free to contribute remaping stubs.
eg:
```cs
class oldClassNameOrClassWithRenamedMembers : NewClass
{
	public void OldFunctionName(string arg) => newFunctionName(arg);
}

```
codegen doesent really need to be touched ever again its just provided to give some insight on how the generated files were created.
