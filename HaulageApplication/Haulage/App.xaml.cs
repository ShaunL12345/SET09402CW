namespace Haulage;
using Haulage.BaseClasses.Accounting;
using System;
using Microsoft.Maui.Controls;

public partial class App : Application
{

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

	}

}
