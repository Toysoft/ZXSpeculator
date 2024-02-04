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

using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using CSharp.Utils.Extensions;
using CSharp.Utils.UI;
using Material.Icons.Avalonia;
using Speculator.ViewModels;

// ReSharper disable UnusedParameter.Local

namespace Speculator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        AddHandler(DragDrop.DropEvent, OnDrop);
        Closing += (_, args) => AppCloseHandler.Instance.OnMainWindowClosing(args);
        Closed += (_, _) => (DataContext as IDisposable)?.Dispose();
    }

    private void OnAboutDialogClicked(object sender, PointerPressedEventArgs e) =>
        Host.CloseDialogCommand.Execute(sender);

    private void OnKeyboardIconLoaded(object sender, RoutedEventArgs e)
    {
        var icon = (MaterialIcon)sender;
        icon.PointerEntered += (_, _) =>
        {
            Keyboard.IsVisible = true;
            Keyboard.Opacity = 1.0;
        };
        icon.PointerExited += (_, _) => Keyboard.Opacity = 0.0;
    }

    private void OnDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetFiles()?.FirstOrDefault() is IStorageFile file)
            ((MainWindowViewModel)DataContext)?.LoadGameRomDirect(file.ToFileInfo());
    }
}