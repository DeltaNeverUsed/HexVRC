# HexVRC
A rather unfaithful recreation of [Hex Casting](https://modrinth.com/mod/hex-casting) for VRChat


[World Link](https://vrchat.com/home/world/wrld_004d1e83-bbb3-4747-93cc-0611445ef6c6/info)


## Dependencies
- [UdonSharp 1.2b1](https://github.com/MerlinVR/UdonSharp) (Included)
- [Orels' Shaders](https://shaders.orels.sh/add-to-vcc)
- [QvPen](https://vpm-catalog.vercel.app/repositories/net.ureishi.vpm/)
- [UdonSharpProfiler](https://github.com/DeltaNeverUsed/UdonSharpProfiler) ([VCC Listing](https://deltaneverused.github.io/VRChatPackages/))
- [Linux SDK Patch](https://github.com/BefuddledLabs/LinuxVRChatSDKPatch) (Optional) ([VCC Listing](https://befuddledlabs.github.io/LinuxVRChatSDKPatch/))

## Setup
1. Install all the packages via the VCC or Alcom, before launching the project.
2. Open the project in your file manager and go to `Packages/com.vrchat.worlds/Integrations` and delete both the UdonSharp directory, and the UdonSharp.meta file.
3. Launch the project.

## Development
If you want to add new patterns take a look at some of the existing ones in `Magic/Runtime/Scripts/Instructions`
Just make sure you put any new patterns in the `BefuddledLabs.Magic.Instructions` or sub namespace.
if you edit the defintions of any instruction you'll have to regenerate the big ol' switch statement.
You can do that by going to `Tools/Magic/Generators/Instruction`.
You'll also have to regenerate the Docs if you change the docs or add a new instruction by going to the Docs object in the scene and hitting in order
1. Clear
2. Generate Images
3. Generate Doc UI
4. Assign