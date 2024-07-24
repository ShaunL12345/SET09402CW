namespace Haulage;

using Haulage.BaseClasses.Accounting;
using System;
using Microsoft.Maui.Controls;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));
    }
}
