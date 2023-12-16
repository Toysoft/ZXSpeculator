﻿// Anyone is free to copy, modify, use, compile, or distribute this software,
// either in source code form or as a compiled binary, for any non-commercial
// purpose.
//
// If modified, please retain this copyright header, and consider telling us
// about your changes.  We're always glad to see how people use our code!
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND.
// We do not accept any liability for damage caused by executing
// or modifying this code.

using System;
using System.IO;
using Speculator.Core;

namespace Speculator.ViewModels;

public class MainWindowViewModel : ViewModelBase, IDisposable
{
    public ZxSpectrum Speccy { get; }
    public ZxDisplay Display { get; } = new ZxDisplay();

    public MainWindowViewModel()
    {
        Speccy =
            new ZxSpectrum(Display)
            .LoadBasicRom()
            .PowerOnAsync()
            //.LoadRom(new FileInfo("ROMs/ManicMiner.sna")) // todo - remove
            ;
    }
    
    public void Dispose() => Speccy.Dispose();
}