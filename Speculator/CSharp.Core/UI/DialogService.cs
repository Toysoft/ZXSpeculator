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

using Avalonia.Media;
using DialogHostAvalonia;
using Material.Icons;

namespace CSharp.Core.UI;

public class DialogService
{
    public static DialogService Instance { get; } = new DialogService();

    public void Warn(string message, string detail, string cancelButton, string actionButton, Action<bool> onClose, MaterialIconKind? icon = null)
    {
        DialogHost.Show(new ConfirmationDialog
            {
                Message = message, 
                Detail = detail,
                CancelButton = cancelButton,
                ActionButton = actionButton,
                ActionBrush = Brushes.Red,
                Icon = icon
            },
            (_, args) => onClose(Convert.ToBoolean(args.Parameter)));
    }
    
    public void ShowMessage(string message, string detail, MaterialIconKind? icon = MaterialIconKind.Information)
    {
        DialogHost.Show(new MessageDialog
            {
                Message = message, 
                Detail = detail,
                Icon = icon
            });
    }
}