using System;
using System.Runtime.CompilerServices;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows.Forms;
using System.Windows.Media;
using Wpf.Ui.Controls;
using MessageBox = Wpf.Ui.Controls.MessageBox;

namespace WinTime.Driver;

public class NotificationDriver
{
    private static NotificationDriver? DriverInstance { get; set; }
    public static NotificationDriver Call()
    {
        return DriverInstance ??= new NotificationDriver();
    }

    public NotificationDriver Notify(string header, string content)
    {
        new MessageBox
        {
            Title = header,
            Content = content,
        }.ShowDialogAsync();
        return this;
    }
}