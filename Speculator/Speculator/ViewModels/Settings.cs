// Code authored by Dean Edis (DeanTheCoder).
// Anyone is free to copy, modify, use, compile, or distribute this software,
// either in source code form or as a compiled binary, for any non-commercial
// purpose.
//
// If you modify the code, please retain this copyright header,
// and consider contributing back to the repository or letting us know
// about your modifications. Your contributions are valued!
//
// THE SOFTWARE IS PROVIDED AS IS, WITHOUT WARRANTY OF ANY KIND.

using CSharp.Utils.Settings;

namespace Speculator.ViewModels;

/// <summary>
/// Application settings.
/// </summary>
public class Settings : UserSettingsBase
{
    public static Settings Instance { get; } = new Settings();

    override protected void ApplyDefaults()
    {
        IsCrt = true;
        IsAmbientBlurred = true;
        IsSoundEnabled = true;
    }
    
    public bool IsCrt
    {
        get => Get<bool>();
        set => Set(value);
    }

    public bool EmulateCursorJoystick
    {
        get => Get<bool>();
        set => Set(value);
    }

    public bool IsAmbientBlurred
    {
        get => Get<bool>();
        set => Set(value);
    }

    public bool IsSoundEnabled
    {
        get => Get<bool>();
        set => Set(value);
    }
}