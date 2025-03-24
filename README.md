# Godot.SimpleCameraMovement
Simple Camera Movement using WASD Zoom In/Out Right Click Dragging
(Windows Only) Mouse/Click Passthrough - let you work around behind your game

# PLEASE ⭐STAR⭐ THE REPO IF YOU LIKE IT! THANKS!

Requirements:
- [Godot Engine - .NET](https://github.com/godotengine/godot/releases/download/4.4-stable/Godot_v4.4-stable_win64.exe.zip)
- [Export templates - .NET](https://github.com/godotengine/godot/releases/download/4.4-stable/Godot_v4.4-stable_mono_export_templates.tpz)

Video Tutorial
- [Part 1](https://youtu.be/kbRINSeGkTQ)
- [Part 2](https://youtu.be/G_HGt1CcRRI)

Transparent Settings
- Set your engine to Compatibility (see image below)
- Navigate to `Project > General`
- `Display > Window` Set settings below
  - `Borderless` -> On
  - `Always On Top` -> On
  - `Transparent` -> On
  - `Per Pixel Transparency` -> On
- `Rendering > Viewport` Set settings below
  - `Transparent Background` -> On
- `WorldEnvironment NODE` -> Set background `Mode` -> Clear color (if still not work try to clear the `Ambient Light` Color aswel

Mouse passthrough settings
- Navigate to Project > Globals
- Browse your script `Scripts\MousePassThrough.cs`
- Node Name: `depends on you`
- Make sure it is `Enabled`

Set to Compatibility (Because old and new Video card wont do transparent background if you are using `Forward+`)
![image](https://github.com/user-attachments/assets/cf241b10-bd54-420a-8f00-8cc8f47246c7)

Build C# 
![image](https://github.com/user-attachments/assets/954540fd-f6a1-4a4f-aa31-32c0fab2d481)



